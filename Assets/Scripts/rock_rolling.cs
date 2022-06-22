using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_rolling : MonoBehaviour
{
    private Animator rock_anim;
    private AudioSource rock_audio;

    void Start()
    {
        rock_anim = this.GetComponent<Animator>();
        rock_audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        rock_anim.SetBool("roll", true);
        rock_audio.Play();
    }
}
