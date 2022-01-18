using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CookSlice : MonoBehaviour
{
    private GameObject Slider_Prefab;
    private GameObject Obj;
    private Slider AnchorPoint;
    private Animator Anim;
    private void Awake()
    {
        Slider_Prefab = Resources.Load("Prefabs/HP_Bar") as GameObject;
    }
    private void Start()
    {
       Obj = Instantiate(Slider_Prefab);
       Obj.transform.name = "Hp";
       Obj.transform.parent = GameObject.Find("ChopUI").transform;
       AnchorPoint = Obj.GetComponent<Slider>();

        Vector3 Pos = new Vector3(
            transform.position.x+0.2f,
            transform.position.y + 1f,
            transform.position.z);

        Obj.transform.position = Camera.main.WorldToScreenPoint(Pos);

        Anim = GameObject.Find("Chef").GetComponent<Animator>();
    }
    private void Update()
    {
        if (AnchorPoint.value != 1)
        {

        }
    }
    private void FixedUpdate()
    {
        if(Anim.GetBool("Chopping"))
            AnchorPoint.value += Time.deltaTime*0.3f;
    }
}
