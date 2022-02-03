using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFollow : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Offset;
    private Animator Anim;
    public bool Hold;
    public bool coll;
    private GameObject ObjectSave;
    private bool flag;
    private GameObject Tmp;
    
    public bool Rice;
    public bool Prawn;
    public bool Cucumber;
    public bool Seaweed;
    private GameObject Rice_plate;
    private GameObject Rice_Cucumber_plate;
    private GameObject Rice_Seaweed_plate;
    private GameObject Seaweed_Cucumber_plate;
    private GameObject Seaweed_plate;
    private GameObject Cucumber_plate;
    private GameObject Prawn_sushi;
    private GameObject Sushi;
    private GameObject Sushi3;
    private GameObject Sushi4;
    private void Awake()
    {
        Rice_plate = Resources.Load("Prefabs/rice_plate") as GameObject;
        Seaweed_plate = Resources.Load("Prefabs/seaweed_plate") as GameObject;
        Rice_Seaweed_plate = Resources.Load("Prefabs/rice+seaweed") as GameObject;
        Cucumber_plate = Resources.Load("Prefabs/cucumber_plate") as GameObject;
        Prawn_sushi = Resources.Load("Prefabs/prawn_sliced") as GameObject;
        Rice_Cucumber_plate = Resources.Load("Prefabs/rice+cucumber") as GameObject;
        Seaweed_Cucumber_plate = Resources.Load("Prefabs/seaweed+cucumber") as GameObject;
        Sushi = Resources.Load("Prefabs/Sushi1") as GameObject;
        Sushi3 = Resources.Load("Prefabs/Sushi3") as GameObject;
        Sushi4 = Resources.Load("Prefabs/Sushi4") as GameObject;
    }
    void Start()
    {
        Player = GameObject.Find("Player");

        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Hold = false;
        coll = false;
        flag = false;
        Rice = false;
        Prawn = false;
        Cucumber = false;
        Seaweed = false;
    }

    void Update()
    {
        if(gameObject.layer == 11)
        {
            BoxCollider BoxColl = gameObject.GetComponent<BoxCollider>();
            //BoxColl.size = new Vector3(0.02f, 0.0016f, 0.003f);
        }
        if (Hold)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Offset = new Vector3(-0.5f, 0.6f, 0.0f);
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Offset = new Vector3(0.5f, 0.6f, 0.0f);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Offset = new Vector3(0.0f, 0.6f, 0.5f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Offset = new Vector3(0.0f, 0.6f, -0.5f);
            }

            Anim.SetBool("Hold", true);

            
            Vector3 Pos = Player.transform.position;
            Pos = Pos + Offset;
            transform.position = Pos;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Hold = false;
                Anim.SetBool("Hold", false);
                this.gameObject.AddComponent<Rigidbody>();
                BoxCollider BoxColl = gameObject.GetComponent<BoxCollider>();
                BoxColl.isTrigger = false;
                Singleton.GetInstance.Holding = false;
            }
        }

        else if (coll && !Singleton.GetInstance.Holding)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Player.transform.position.x > transform.position.x)
                    Offset = new Vector3(-0.5f, 0.6f, 0.0f);
                else
                    Offset = new Vector3(0.5f, 0.6f, 0.0f);

                gameObject.layer = 9;
                Hold = true;
                Anim.SetBool("Hold", true);
                Rigidbody Rigid = gameObject.GetComponent<Rigidbody>();
                Destroy(Rigid);
                coll = false;
                BoxCollider BoxColl = gameObject.GetComponent<BoxCollider>();
                BoxColl.isTrigger = false;
                Singleton.GetInstance.PlayerColl = false;
                Singleton.GetInstance.Holding = true;
            }
            if(flag)
            {
                if(ObjectSave.name=="Rice")
                {
                    if (ObjectSave.GetComponent<RicePot>())
                    {
                        RicePot Rpot = ObjectSave.GetComponent<RicePot>();
                        if (Rpot.Pot_Finish)
                        {
                            Destroy(ObjectSave);
                            Rice = true;
                        }
                    }
                }
                else if(ObjectSave.name=="Seaweed")
                {
                    Destroy(ObjectSave);
                    Seaweed = true;
                }
                else if(ObjectSave.name== "Cucumber_slice")
                {
                    CookSlice Cslice = ObjectSave.GetComponent<CookSlice>();
                    if(Cslice.Chop_Finish)
                    {
                        Destroy(ObjectSave);
                        Cucumber = true;
                    }
                }
                else if(ObjectSave.name== "Prawn_Slice")
                {
                    CookSlice Cslice = ObjectSave.GetComponent<CookSlice>();
                    if (Cslice.Chop_Finish)
                    {
                        Destroy(ObjectSave);
                        Prawn = true;
                    }
                }

                // ½Ò + ¹Ì¿ª + ¿ÀÀÌ + ¿Õ»õ¿ì
                if (Rice && Prawn && Seaweed && Cucumber)
                {
                    Destroy(Tmp);
                    Tmp = Instantiate(Sushi3);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ½Ò + ¹Ì¿ª + ¿ÀÀÌ
                else if (Rice && !Prawn && Seaweed && Cucumber)
                {
                    Destroy(Tmp);
                    Tmp = Instantiate(Sushi);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ½Ò + ¹Ì¿ª + ¿Õ»õ¿ì
                else if (Rice && Prawn && Seaweed && !Cucumber)
                {
                    Destroy(Tmp);
                    Tmp = Instantiate(Sushi4);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ¹Ì¿ª + ¿ÀÀÌ
                else if (!Rice && !Prawn && Seaweed && Cucumber)
                {
                    Destroy(Tmp);
                    Tmp = Instantiate(Seaweed_Cucumber_plate);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }

                // ½Ò + ¹Ì¿ª
                else if (Rice && !Prawn && Seaweed && !Cucumber)
                {
                    Destroy(Tmp);
                    Tmp = Instantiate(Rice_Seaweed_plate);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ½Ò + ¿ÀÀÌ
                else if (Rice && !Prawn && !Seaweed && Cucumber)
                {
                    Destroy(Tmp);
                    Tmp = Instantiate(Rice_Cucumber_plate);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ½Ò
                else if(Rice&&!Prawn&&!Seaweed&&!Cucumber)
                {
                    Tmp = Instantiate(Rice_plate);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = Vector3.zero;
                    Tmp.transform.position = Pos + mOffset;
                }
                // ¹Ì¿ª
                else if(!Rice && !Prawn && Seaweed && !Cucumber)
                {
                    Tmp = Instantiate(Seaweed_plate);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ¿ÀÀÌ
                else if (!Rice && !Prawn && !Seaweed && Cucumber)
                {
                    Tmp = Instantiate(Cucumber_plate);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                // ¿Õ»õ¿ì
                else if (!Rice && Prawn && !Seaweed && !Cucumber)
                {
                    Tmp = Instantiate(Prawn_sushi);
                    Tmp.transform.parent = transform;
                    Vector3 Pos = transform.position;
                    Vector3 mOffset = new Vector3(0.0f, 0.2f, 0.0f);
                    Tmp.transform.position = Pos + mOffset;
                }
                flag = false;
            }
                
        }
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
        if (other.transform.name != "-mesh"&&other.gameObject.layer!=7)
        {
            if (other.transform.name != "Player")
            {
                flag = true;
                ObjectSave = other.gameObject;
            }
            coll = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name != "-mesh" && other.gameObject.layer != 7)
        {
            coll = false;
        }
    }
}
