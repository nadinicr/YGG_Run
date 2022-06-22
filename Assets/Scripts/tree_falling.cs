using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_falling : MonoBehaviour
{
    private Animator tree_anim;
    private AudioSource tree_fall;

    void Start()
    {
        tree_anim = this.GetComponent<Animator>();
        tree_fall = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        tree_anim.SetBool("fall", true);
        tree_fall.Play();
    }
}
