using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColl : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name != "-mesh")
        {
            Singleton.GetInstance.PlayerColl = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name != "-mesh")
        {
            Singleton.GetInstance.PlayerColl = false;
        }
    }
}
