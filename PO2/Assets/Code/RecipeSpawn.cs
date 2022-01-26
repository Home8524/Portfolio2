using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Rec1;
    [SerializeField] private GameObject Rec2;
    private float Timer;
    private int Cnt;
    private void Awake()
    {
        Rec1 = Resources.Load("Prefabs/Recipe1") as GameObject;
        Rec2 = Resources.Load("Prefabs/Recipe2") as GameObject;
    }
    private void Start()
    {
        GameObject Obj = Instantiate(Rec1);
        Obj.transform.name = "Re1";
        Obj.transform.position = new Vector3(600.0f, 407.0f, 0.0f);
        Obj.transform.parent = GameObject.Find("UI").transform;
        GameObject Obj2 = Instantiate(Rec2);
        Obj2.transform.name = "Re2";
        Obj2.transform.position = new Vector3(800.0f, 407.0f, 0.0f);
        Obj2.transform.parent = GameObject.Find("UI").transform;
        Singleton.GetInstance.Recipecount = 2;
        Singleton.GetInstance.RecipeList.Add(Obj);
        Singleton.GetInstance.RecipeList.Add(Obj2);

        Timer = 0.0f;
        //foreach(Gameobject tmp in sing~~) 
        Cnt = 2;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            foreach(GameObject tmp in Singleton.GetInstance.RecipeList)
            {
                Debug.Log(tmp.transform.name);
            }
        }
    }
    private void FixedUpdate()
    {
        Timer +=  0.1f;
        if (Timer >= 100 && Singleton.GetInstance.Recipecount<8)
        {
            Timer = 0;
            int randtmp = Random.Range(0,2);
            GameObject Obj;
            Singleton.GetInstance.Recipecount++;
            Cnt++;
            if (randtmp == 0)
            {
                Obj = Instantiate(Rec1);
                Obj.transform.name = "Re"+Cnt;
            }
            else
            {
                Obj = Instantiate(Rec2);
                Obj.transform.name = "Re"+Cnt;
            }

            Obj.transform.parent = GameObject.Find("UI").transform;
            Obj.transform.position = new Vector3(130.0f*Singleton.GetInstance.Recipecount, 407.0f, 0.0f);            
            Singleton.GetInstance.RecipeList.Add(Obj);
        }
    }
}
