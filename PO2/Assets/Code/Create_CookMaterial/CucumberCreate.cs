using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberCreate : MonoBehaviour
{
    private bool coll;
    [SerializeField] private GameObject Cucumber;
    private void Awake()
    {
        Cucumber = Resources.Load("Prefabs/cucumber_default") as GameObject;
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
            Obj = Instantiate(Cucumber);
            Obj.transform.name = "Cucumber";
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
