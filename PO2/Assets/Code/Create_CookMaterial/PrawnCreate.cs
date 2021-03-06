using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrawnCreate : MonoBehaviour
{
    private bool coll;
    [SerializeField] private GameObject Prawn;
    private void Awake()
    {
        Prawn = Resources.Load("Prefabs/prawn_default") as GameObject;
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
            Obj = Instantiate(Prawn);
            Obj.transform.name = "Prawn";
            Obj.transform.parent = GameObject.Find("CookedBox").transform;
            Obj.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
            coll = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Player")
            coll = false;
    }
}
