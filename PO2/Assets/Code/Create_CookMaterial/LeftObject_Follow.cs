using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftObject_Follow : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Offset;
    private Animator Anim;
    private bool Hold;
    void Start()
    {
        Player = GameObject.Find("Player");
        Offset = new Vector3(-0.5f, 0.4f, 0.0f);
        Anim = GameObject.Find("Chef").GetComponent<Animator>();
        Hold = true;
    }

    void Update()
    {
        if (Hold)
        {
            Anim.SetBool("Hold", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Offset = new Vector3(-0.5f, 0.4f, 0.0f);
                transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Offset = new Vector3(0.5f, 0.4f, 0.0f);
                transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Offset = new Vector3(0.0f, 0.4f, 0.5f);
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Offset = new Vector3(0.0f, 0.4f, -0.5f);
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            }

            Vector3 Pos = Player.transform.position;
            Pos = Pos + Offset;
            transform.position = Pos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hold = false;
            Anim.SetBool("Hold", false);
            this.gameObject.AddComponent<Rigidbody>();
        }
    }
}
