using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characther : MonoBehaviour
{
    private Animator animacao; //animacao
    public Rigidbody rb; // rigidbody
    private AudioSource damage_audio; //audio
    private AudioSource final_damage_audio; //audio
    private AudioSource grass; //audio
    private AudioSource loser_audio; //audio
    private AudioSource winner_audio; //audio

    public Canvas gameOver_canvas;// get canvas
    public Canvas youWin_canvas;// get canvas
    public Canvas uriel_normal;// get canvas
    public Canvas uriel_pistol;// get canvas
    public Canvas uriel_acabed;// get canvas
    public Canvas uriel_died;// get canvas


    //variaveis
    private int hits = 0;
    private float speed = 2.5f;

    void Start()
    {
        //animacao
        animacao = this.GetComponent<Animator>();

        //rigid body
        rb = this.GetComponent<Rigidbody>();

        //audio
        damage_audio = this.GetComponent<AudioSource>();
        final_damage_audio = this.GetComponent<AudioSource>();
        AudioSource[] audios = GetComponents<AudioSource>();
        damage_audio = audios[0];
        final_damage_audio = audios[1];
        grass = audios[2];
        loser_audio = audios[3];
        winner_audio = audios[4];

        grass.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //CORRER
        transform.Translate(0, 0, speed * Time.deltaTime);

        // VERIFICA SE O PERSONAGEM MORREU
        if (GetComponent<Animator>().GetBool("die") == true) 
        {
            speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colidiu");
        if (other.CompareTag("Enviroment"))
        {
            hits += 1;
            speed += 0.6f;
            damage_audio.Play();

            // CONDICAO DO AUMENTO DA VELOCIDADE
            if (speed >= 6  && speed <= 10)
            {
                animacao.SetBool("running_fast", true);
                animacao.SetBool("super_running", false);
                animacao.SetBool("die", false);
            }
            else if (speed > 10) 
            {
                animacao.SetBool("running_fast", false);
                animacao.SetBool("super_running", true);
                animacao.SetBool("die", false);
            }

            //HUD
            if (hits == 6) {
                uriel_normal.GetComponent<Canvas>().enabled = false;
                uriel_pistol.GetComponent<Canvas>().enabled = true;
            }
            else if (hits == 12)
            {
                uriel_pistol.GetComponent<Canvas>().enabled = false;
                uriel_acabed.GetComponent<Canvas>().enabled = true;
            }
            else if (hits == 16)
            {
                uriel_acabed.GetComponent<Canvas>().enabled = false;
                uriel_died.GetComponent<Canvas>().enabled = true;
            }


            // CONDICAO DE VITORIA
            if (hits == 16) 
            {
                //animacoes
                animacao.SetBool("running_fast", false);
                animacao.SetBool("super_running", false);
                animacao.SetBool("die", true);
                //velocidade
                speed = 0;
                transform.Translate(0, 0, speed * Time.deltaTime);
                //audio
                winner_audio.Play();
                final_damage_audio.Play();
                grass.Stop();
                //canvas
                youWin_canvas.GetComponent<Canvas>().enabled = true;
            }

            Debug.Log(speed);
        }

        //CONDICAO DE DERROTA
        if (other.CompareTag("GameOver")) 
        {
            gameOver_canvas.GetComponent<Canvas>().enabled = true;
            loser_audio.Play();
            grass.Stop();
            Time.timeScale = 0;
        }

    }


}
