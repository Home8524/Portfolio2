using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCreate : MonoBehaviour
{
    private bool coll;
    [SerializeField] private GameObject Rice;
    private void Awake()
    {
        Rice = Resources.Load("Prefabs/rice_default") as GameObject;
    }
    void Start()
    {
        coll = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coll && !Singleton.GetInstance.Holding)
        {
            GameObject Obj;
            Obj = Instantiate(Rice);
            Obj.transform.name = "Rice";
            Obj.transform.parent = GameObject.Find("CookedBox").transform;
            Obj.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("!");
        coll = true;
    }
    private void OnTriggerExit(Collider other)
    {
        coll = false;
    }
}
