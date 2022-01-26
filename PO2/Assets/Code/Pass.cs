using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    private bool coll;
    private GameObject Plate;
    private void Start()
    {
        coll = false;
    }
    private void Update()
    {
        if(coll)
        {
            PlateFollow Tmp = Plate.GetComponent<PlateFollow>();
            foreach(GameObject Rec in Singleton.GetInstance.RecipeList)
            {
                bool breaktest=false;
                if(Rec.tag=="Re1"&&Tmp.Cucumber&&Tmp.Rice&&Tmp.Seaweed&&!Tmp.Prawn)
                {
                    for(int i = Singleton.GetInstance.RecipeList.Count-1;i>=0;--i)
                    {
                        if(Singleton.GetInstance.RecipeList[i].name==Rec.name)
                        {
                            Singleton.GetInstance.RecipeList.Remove(Singleton.GetInstance.RecipeList[i]);
                            Destroy(Rec);
                            Singleton.GetInstance.Recipecount--;
                            breaktest = true;
                        }
                    }
                }
                else if (Rec.tag == "Re2" && !Tmp.Cucumber && !Tmp.Rice && !Tmp.Seaweed && Tmp.Prawn)
                {
                    for (int i = Singleton.GetInstance.RecipeList.Count - 1; i >= 0; --i)
                    {
                        if (Singleton.GetInstance.RecipeList[i].transform.name == Rec.transform.name)
                        {
                            Singleton.GetInstance.RecipeList.Remove(Singleton.GetInstance.RecipeList[i]);
                            Destroy(Rec);
                            Singleton.GetInstance.Recipecount--;
                            breaktest = true;
                        }
                    }
                }
                if (breaktest)
                    break;
             }
            Destroy(Plate);
            Plate = null;
            coll = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Plate")
        {
            coll = true;
            Plate = other.gameObject;
        }
    }
}
