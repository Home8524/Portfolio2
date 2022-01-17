using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColl : MonoBehaviour
{
    private bool coll;
    GameObject Object;
    private bool exist;
    private bool flag;
    public Vector3 Offset = new Vector3(0.0f, 0.6f, 0.2f);
    void Start()
    {
        coll = false;
        exist = false;
        flag = false;
    }
    
    void Update()
    {
        if(coll)
        {
            Object.gameObject.layer = 11;
            Rigidbody Rigid =  Object.GetComponent<Rigidbody>();
            Destroy(Rigid);
            BoxCollider BoxColl = Object.GetComponent<BoxCollider>();
            BoxColl.isTrigger = true;
            BoxColl.size = new Vector3(2.0f, 1.0f, 0.5f);
            Vector3 Pos = transform.position;
            
            Object.transform.position = Pos+Offset;
            Object.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            coll = false;
        }
        if(flag&&Input.GetKeyDown(KeyCode.Space))
        {
            exist = false;
            flag = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9&&!exist)
        {
            Object = other.gameObject;
            coll = true;
            exist = true;
        }
        if (other.gameObject.layer == 8 && exist &&!Singleton.GetInstance.Holding)
            flag = true;
    }
}
