using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIcon : MonoBehaviour
{
    public GameObject Plate;
    public GameObject Rice;
    public GameObject Prawn;
    public GameObject Seaweed;
    public GameObject Cucumber;
    void Update()
    {
        if(Plate)
        {
            PlateFollow Tmp = Plate.GetComponent<PlateFollow>();
            if (Tmp.Cucumber)
                Cucumber.SetActive(true);
            else
                Cucumber.SetActive(false);

            if (Tmp.Rice)
                Rice.SetActive(true);
            else
                Rice.SetActive(false);

            if (Tmp.Prawn)
                Prawn.SetActive(true);
            else
                Prawn.SetActive(false);

            if (Tmp.Seaweed)
                Seaweed.SetActive(true);
            else
                Seaweed.SetActive(false);

            Vector3 Pos = new Vector3(
                Plate.transform.position.x-0.3f,
                Plate.transform.position.y+0.2f ,
                Plate.transform.position.z);

            transform.position = Camera.main.WorldToScreenPoint(Pos);
        }
        else
        {
            Cucumber.SetActive(false);
            Rice.SetActive(false);
            Prawn.SetActive(false);
            Seaweed.SetActive(false);
        }
    }
}
