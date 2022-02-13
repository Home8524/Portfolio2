using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Update()
    {
        GameObject Obj = GameObject.Find("Player");
        Vector3 Pos = Obj.transform.position;
        Pos.y += 28;
        Pos.z -= 10;
        transform.position = Pos;


    }
}
