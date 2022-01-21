using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Plate")
        {
            PlateFollow Tmp = other.GetComponent<PlateFollow>();
            Tmp.Hold = true;
            Tmp.Cucumber = false;
            Tmp.Prawn = false;
            Tmp.Rice = false;
            Tmp.Seaweed = false;
            Transform[] Clist = Tmp.GetComponentsInChildren<Transform>();
            Destroy(Tmp.GetComponent<Rigidbody>());
            for(int i=1; i<Clist.Length;++i)
            {
                if (Clist[i] != transform)
                    Destroy(Clist[i].gameObject);
            }
        }
    }
}
