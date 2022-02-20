using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageColl : MonoBehaviour
{
    private string[] SceneName = { "Stage0", "Stage1" };

    private int Index;
    public GameObject Obj;
    private bool pass;
    private void Start()
    {
        Index = 1;
        pass = false;
    }
    private void Update()
    {
        if(pass&&Input.GetKeyDown(KeyCode.Space))
        {
            SetNextScene();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 Pos = new Vector3(
            transform.position.x - 0.2f,
            transform.position.y + 1.5f,
            transform.position.z);

        Obj.transform.position = Camera.main.WorldToScreenPoint(Pos);
        Obj.SetActive(true);
        pass = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Obj.SetActive(false);
        pass = false;
    }

    void SetNextScene()
    {
        if (Index >= SceneName.Length)
            return;

        LoadingController.SetLoad(SceneName[Index]);
        Index++;
    }
}
