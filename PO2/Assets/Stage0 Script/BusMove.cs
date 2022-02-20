using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMove : MonoBehaviour
{
    [SerializeField] AudioSource AS;

    private void Start()
    {
        AS = transform.GetComponent<AudioSource>();
    }
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        Vector3 Pos = new Vector3(Hor, 0.0f, Ver);
        if(!(Hor==0 && Ver ==0))
        {
            transform.position += Pos * 5.0f * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Pos),
                10.0f*Time.deltaTime);
            //AS.Play();
            AS.volume = 0.5f;
        }
        else
        {
            AS.volume = 0.0f;
        }
    }
}
