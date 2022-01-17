using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedCreate : MonoBehaviour
{
    private bool coll;
    [SerializeField] private GameObject Seaweed;
    private void Awake()
    {
        Seaweed = Resources.Load("Prefabs/seaweed_default") as GameObject;
    }
    void Start()
    {
        coll = false;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&coll && !Singleton.GetInstance.Holding)
        {
            GameObject Obj;
            Obj = Instantiate(Seaweed);
            Obj.transform.name = "Seaweed";
            Obj.transform.parent = GameObject.Find("CookedBox").transform;
            Obj.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        coll = true;
    }
    private void OnTriggerExit(Collider other)
    {
        coll = false;
    }
}
