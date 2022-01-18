using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFollow : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Offset;
    private Animator Anim;
    private bool Hold;
    private bool coll;
    void Start()
    {
        Player = GameObject.Find("Player");

        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Hold = false;
        coll = false;
        //Singleton.GetInstance.Holding = true;
    }

    void Update()
    {
        if(gameObject.layer == 11)
        {
            BoxCollider BoxColl = gameObject.GetComponent<BoxCollider>();
            BoxColl.size = new Vector3(0.02f, 0.0016f, 0.003f);
        }
        if (Hold)
        {
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
                BoxColl.isTrigger = true;
                Singleton.GetInstance.PlayerColl = false;
                Singleton.GetInstance.Holding = true;
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
