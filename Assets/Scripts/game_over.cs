using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_over : MonoBehaviour
{
    public Canvas gameOver_canvas;
    private AudioSource gameOver_audio;

    // Start is called before the first frame update
    void Start()
    {
        gameOver_audio = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colidiu");
        if (other.CompareTag("Player"))
        {
            gameOver_canvas.GetComponent<Canvas>().enabled = true;
            gameOver_audio.Play();
            Time.timeScale = 0;
        }
    }
}
