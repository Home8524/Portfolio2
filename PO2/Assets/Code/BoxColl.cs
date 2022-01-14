using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColl : MonoBehaviour
{
    private bool coll;
    GameObject Object;
    void Start()
    {
        coll = false;    
    }
    
    void Update()
    {
        if(coll&&Input.GetKeyDown(KeyCode.Space))
        {
            Object.gameObject.layer = 11;
            Rigidbody Rigid = Object.GetComponent<Rigidbody>();
            Destroy(Rigid);

            Vector3 Pos = transform.position;
            Vector3 Offset = new Vector3(0.2f, 0.6f, 0.0f);
            Object.transform.position = Pos;
            Object.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10&&other.transform.name != "-mesh")
        {
            Object = other.gameObject;
            coll = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.name != "-mesh")
            coll = false;
    }
}
