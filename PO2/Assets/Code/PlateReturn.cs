using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateReturn : MonoBehaviour
{
    private GameObject DirtyPlate;
    private bool Flag = false;
    private void Awake()
    {
        DirtyPlate = Resources.Load("Prefabs/DirtyPlate") as GameObject;
    }
    private void Update()
    {
        if(Singleton.GetInstance.Placecnt!=4&&!GameObject.Find("DirtyPlate"))
        {
            if(!Flag)
                Invoke("PlaceCreate", 8.0f);
            Flag = true;
        }
    }

    void PlaceCreate()
    {
        GameObject Obj = Instantiate(DirtyPlate);
        Obj.transform.name = "DirtyPlate";
        Obj.transform.parent = transform;
        Vector3 Offset = new Vector3(0, 0.5f, 0.0f);
        Obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Vector3 Pos = transform.position;
        Obj.transform.position = Pos + Offset;
        Flag = false;
    }
}
