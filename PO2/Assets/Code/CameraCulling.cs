using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCulling : MonoBehaviour
{

    private LayerMask Mask;

    void Start()
    {
        Mask =LayerMask.NameToLayer("Throw");
        Camera.main.cullingMask = ~(1 << Mask);   
    }
    
}
