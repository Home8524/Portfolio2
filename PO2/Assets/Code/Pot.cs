using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private bool coll;
    GameObject Object;
    private bool exist;
    private bool flag;
    private Vector3 Offset = new Vector3(0.0f, 0.0f, 0.2f);
    void Start()
    {
        coll = false;
        exist = false;
        flag = false;
    }

    void Update()
    {
        if (coll)
        {
            Object.gameObject.layer = 11;
            Rigidbody Rigid = Object.GetComponent<Rigidbody>();
            Destroy(Rigid);
            BoxCollider BoxColl = Object.GetComponent<BoxCollider>();
            BoxColl.isTrigger = true;
            BoxColl.size = new Vector3(0.5f, 1.0f, 2.0f);
            Vector3 Pos = transform.position;

            Object.transform.position = Pos + Offset;
            Object.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            coll = false;
            LeftObject_Follow Tmp = Object.GetComponent<LeftObject_Follow>();
            Destroy(Tmp);
            if(!Object.GetComponent<RicePot>())
                Object.AddComponent<RicePot>();
        }
        if (flag && Input.GetKeyDown(KeyCode.Space))
        {
            exist = false;
            flag = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && !exist)
        {
            Object = other.gameObject;
            coll = true;
            exist = true;
        }
        if (other.gameObject.layer == 8 && exist && !Singleton.GetInstance.Holding)
            flag = true;
    }
}
