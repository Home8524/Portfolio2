using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CookSlice : MonoBehaviour
{
    private GameObject Slider_Prefab;
    private GameObject Obj;
    private Slider AnchorPoint;
    private Animator Anim;
    private bool Hold;
    private Vector3 Offset;
    private bool coll;
    private GameObject Player;
    private bool Chop_coll;
    public bool Chop_Finish = false;
    private void Awake()
    {
        Slider_Prefab = Resources.Load("Prefabs/HP_Bar") as GameObject;
    }
    private void Start()
    {
       Obj = Instantiate(Slider_Prefab);
       Obj.transform.name = "Hp";
       Obj.transform.parent = GameObject.Find("ChopUI").transform;
       AnchorPoint = Obj.GetComponent<Slider>();

        Vector3 Pos = new Vector3(
            transform.position.x+0.2f,
            transform.position.y + 1f,
            transform.position.z);

        Obj.transform.position = Camera.main.WorldToScreenPoint(Pos);

        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Hold = false;
        Offset = Vector3.zero;
        coll = false;
        Player = GameObject.Find("Player");
        Chop_coll = false;
        transform.parent = GameObject.Find("CookedBox").transform;
    }
    private void Update()
    {
        if (Hold)
        {
            Anim.SetBool("Hold", true);
            BoxCollider BoxColl = gameObject.GetComponent<BoxCollider>();
            if (transform.name == "Prawn_Slice")
                BoxColl.size = new Vector3(0.3f, 1.0f, 3.0f);
            else
                BoxColl.size = new Vector3(0.03f, 0.1f, 0.2f);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Offset = new Vector3(-0.5f, 0.6f, 0.0f);
                transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Offset = new Vector3(0.5f, 0.6f, 0.0f);
                transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Offset = new Vector3(0.0f, 0.6f, 0.5f);
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Offset = new Vector3(0.0f, 0.6f, -0.5f);
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }

            if (!Singleton.GetInstance.PlayerColl)
            {
                Vector3 Pos = Player.transform.position;
                Pos = Pos + Offset;
                transform.position = Pos;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Hold = false;
                Anim.SetBool("Hold", false);
                this.gameObject.AddComponent<Rigidbody>();
                BoxColl.isTrigger = false;
                Singleton.GetInstance.Holding = false;
            }
        }

        else if (coll && !Singleton.GetInstance.Holding)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Obj.SetActive(false);
                gameObject.layer = 9;
                Hold = true;
                Anim.SetBool("Hold", true);
                Rigidbody Rigid = gameObject.GetComponent<Rigidbody>();
                Destroy(Rigid);
                coll = false;
                BoxCollider BoxColl = gameObject.GetComponent<BoxCollider>();
                BoxColl.isTrigger = true;
                Singleton.GetInstance.PlayerColl = false;
                Singleton.GetInstance.Holding = true;
                Chop_coll = false;
            }
        }
        if (Chop_coll)
        {
            Vector3 Pos = new Vector3(
            transform.position.x + 0.2f,
            transform.position.y + 1f,
            transform.position.z);

            Obj.transform.position = Camera.main.WorldToScreenPoint(Pos);
            Obj.SetActive(true);
            Chop_coll = false;
        }
        if (AnchorPoint.value == 1)
        {
            Chop_Finish = true;
        }
    }
    private void FixedUpdate()
    {
        if(Anim.GetBool("Chopping"))
            AnchorPoint.value += Time.deltaTime*0.3f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name != "-mesh")
        {
            coll = true;
        }
        else
            gameObject.layer = 10;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name != "-mesh")
        {
            coll = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name != "-mesh")
        {
            coll = true;
        }
        if (other.transform.name =="Chop")
        {
            Chop_coll = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name != "-mesh")
        {
            coll = false;
        }
        if (other.transform.name == "Chop")
        {
            Chop_coll = false;
        }
    }
}
