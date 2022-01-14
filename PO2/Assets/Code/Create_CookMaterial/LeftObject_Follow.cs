using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftObject_Follow : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Offset;
    private Animator Anim;
    private bool Hold;
    private bool coll;
    void Start()
    {
        Player = GameObject.Find("Player");
        Offset = new Vector3(-0.5f, 0.6f, 0.0f);
        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Hold = true;
        coll = false;
    }

    void Update()
    {
        if (Hold)
        {
            Anim.SetBool("Hold", true);
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

            if(!Singleton.GetInstance.PlayerColl)
            {
                Vector3 Pos = Player.transform.position;
                Pos = Pos + Offset;
                transform.position = Pos;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.layer = 10;
                Hold = false;
                Anim.SetBool("Hold", false);
                this.gameObject.AddComponent<Rigidbody>();
            }
        }

        else if(coll)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.layer = 9;
                Hold = true;
                Anim.SetBool("Hold", true);
                Rigidbody Rigid= gameObject.GetComponent<Rigidbody>();
                Destroy(Rigid);
                coll = false;
                Singleton.GetInstance.PlayerColl = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name != "-mesh")
        {
            coll = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name != "-mesh")
        {
            coll = false;
        }
    }
}
