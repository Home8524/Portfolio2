using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sink : MonoBehaviour
{
    private bool coll=false;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    private int tmp;
    private Animator Anim;
    private bool Pcoll = false;
    private GameObject Slider_Prefab;
    private GameObject Obj;
    private Slider AnchorPoint;
    private void Awake()
    {
        Slider_Prefab = Resources.Load("Prefabs/HP_Bar") as GameObject;
    }
    private void Start()
    {
        tmp = 0;
        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Obj = Instantiate(Slider_Prefab);
        Obj.transform.name = "Hp" + Singleton.GetInstance.Slicecount;
        Singleton.GetInstance.Slicecount++;
        Obj.transform.parent = GameObject.Find("ChopUI").transform;
        AnchorPoint = Obj.GetComponent<Slider>();

        Vector3 Pos = new Vector3(
            transform.position.x + 0.8f,
            transform.position.y + 0.0f,
            transform.position.z - 0.4f);

        Obj.transform.position = Camera.main.WorldToScreenPoint(Pos);
        Obj.SetActive(false);
    }
    private void Update()
    {
        if(coll)
        {
            tmp = 4 - Singleton.GetInstance.Placecnt;
            Destroy(GameObject.Find("DirtyPlate"));
            switch(tmp)
            {
                case 1:
                    P1.SetActive(true);
                    P2.SetActive(false);
                    P3.SetActive(false);
                    break;
                case 2:
                    P1.SetActive(true);
                    P2.SetActive(true);
                    P3.SetActive(false);
                    break;
                default:
                    P1.SetActive(true);
                    P2.SetActive(true);
                    P3.SetActive(true);
                    break;
            }
            coll = false;
        }
        if(tmp!=0&&Pcoll)
        {
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
               Anim.SetBool("Washing", true);
                Obj.SetActive(true);
            }
            if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                Anim.SetBool("Washing", false);
                Obj.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DirtyPlate")
            coll = true;
        if (other.name == "Player")
            Pcoll = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            Pcoll = false;
    }
}
