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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
