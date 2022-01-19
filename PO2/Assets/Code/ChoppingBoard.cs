using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    [SerializeField] private GameObject CucumberPrefab;
    [SerializeField] private GameObject PrawnPrefab;
    [SerializeField] private GameObject PrawnPrefab2;
    private bool coll_c;
    private bool coll_p;
    private bool coll;
    private bool Player_coll;
    private GameObject Object;
    private Vector3 Offset;
    public int BoxNum;
    public GameObject Knife;
    private Animator Anim;
    public GameObject Knife1;
    public GameObject Knife2;
    public GameObject Knife3;
    private void Awake()
    {
        CucumberPrefab = Resources.Load("Prefabs/cucumber_slice") as GameObject;
        PrawnPrefab = Resources.Load("Prefabs/prawn_slicing") as GameObject;
        PrawnPrefab2 = Resources.Load("Prefabs/prawn_sliced") as GameObject;
    }
    private void Start()
    {
        coll_c = false;
        coll_p = false;
        coll = false;
        Offset = new Vector3(0.2f,0.6f,0.0f);
        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Player_coll = false;
    }
    private void Update()
    {
        if (coll)
        {
            coll = false;
            Object.gameObject.layer = 11;
            Rigidbody Rigid = Object.GetComponent<Rigidbody>();
            Destroy(Rigid);
            BoxCollider BoxColl = Object.GetComponent<BoxCollider>();
            BoxColl.isTrigger = true;
            BoxColl.size = new Vector3(0.5f, 1.0f, 2.0f);
            Vector3 Pos = transform.position;

            Singleton.GetInstance.Holding = false;
            switch (BoxNum)
            {
                case 1:
                    Knife1.SetActive(false);
                    break;
                case 2:
                    Knife2.SetActive(false);
                    break;
                case 3:
                    Knife3.SetActive(false);
                    break;
                default:
                    break;
            }

            Object.transform.position = Pos + Offset;
            Object.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            if(Object.transform.name=="Prawn_Slice")
            {
                Object.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                BoxColl.size = new Vector3(3.0f, 1.0f, 0.3f);
            }
            else if(Object.transform.name=="Cucumber_slice")
            {
                BoxColl.size = new Vector3(0.03f, 0.1f, 0.3f);
            }
        }
        else if (coll_c)
        {
            Destroy(Object);
            Object = Instantiate(CucumberPrefab);
            Object.transform.name = "Cucumber_slice";
            Vector3 Pos = transform.position;

            Object.transform.position = Pos + Offset;
            Object.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            coll_c = false;
            Singleton.GetInstance.Holding = false;
            switch (BoxNum)
            {
                case 1:
                    Knife1.SetActive(false);
                    break;
                case 2:
                    Knife2.SetActive(false);
                    break;
                case 3:
                    Knife3.SetActive(false);
                    break;
                default:
                    break;
            }

        }
        else if (coll_p)
        {
            Destroy(Object);
            Object = Instantiate(PrawnPrefab);
            Object.transform.name = "Prawn_Slice";
            Vector3 Pos = transform.position;

            Object.transform.position = Pos + Offset;
            Object.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            Singleton.GetInstance.Holding = false;
            switch (BoxNum)
            {
                case 1:
                    Knife1.SetActive(false);
                    break;
                case 2:
                    Knife2.SetActive(false);
                    break;
                case 3:
                    Knife3.SetActive(false);
                    break;
                default:
                    break;
            }

            coll_p = false;
        }
        if(Player_coll&&Input.GetKeyDown(KeyCode.LeftControl) && !Singleton.GetInstance.Holding)
        {
            Anim.SetBool("Chopping", true);
            Knife.SetActive(true);
        }
        else if(Player_coll&&Input.GetKeyUp(KeyCode.LeftControl) && !Singleton.GetInstance.Holding)
        {
            Anim.SetBool("Chopping", false);
            Knife.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Space)&&Player_coll)
        {
            if (Knife1.activeSelf == false && BoxNum ==1)
                Knife1.SetActive(true);
            if (Knife2.activeSelf == false && BoxNum == 2)
                Knife2.SetActive(true);
            if (Knife3.activeSelf == false && BoxNum == 3)
                Knife3.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Cucumber")
        {
            Object = other.gameObject;
            coll_c = true;
        }
        else if (other.transform.name == "Prawn")
        {
            Object = other.gameObject;
            coll_p = true;
        }
        else if (other.transform.name == "Player")
            Player_coll = true;
        else if(other.transform.name!="Player")
        {
            Object = other.gameObject;
            coll = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Cucumber")
            coll_c = false;
        else if (other.transform.name == "Prawn")
            coll_p = false;
        else if (other.transform.name == "Player")
            Player_coll = false;
        else if (other.transform.name != "Player")
            coll = false;
    }
}
