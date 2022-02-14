using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCulling : MonoBehaviour
{

    private LayerMask Mask;
    public AudioClip Ready;
    public AudioClip MainBgm;
    private AudioSource As;
    void Start()
    {
        Mask =LayerMask.NameToLayer("Throw");
        Camera.main.cullingMask = ~(1 << Mask);
        As = transform.GetComponent<AudioSource>();
        As.clip = Ready;
        As.Play();
        Invoke("MusicChange", 3.0f);
    }

    void MusicChange()
    {
        As.clip = MainBgm;
        As.Play();
    }

}
