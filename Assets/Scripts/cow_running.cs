using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow_running : MonoBehaviour
{
    private Animator cow_anim;
    private AudioSource cow_audio;

    void Start()
    {
        cow_anim = this.GetComponent<Animator>();
        cow_audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        cow_anim.SetBool("run", true);
        cow_audio.Play();
    }
}
