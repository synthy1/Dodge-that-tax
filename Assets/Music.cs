using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public TimerScript time;
    GameManager game;
    AudioSource musicOrogin;
    public AudioClip[] musicOptions;
    bool musicplaying = false;


    void Start()
    {
        musicOrogin = gameObject.GetComponent<AudioSource>();
        game = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(time.timer <= 45 && time.gameStartl)
        {
            musicplaying = false;
            if (musicplaying == false)
            {
                musicOrogin.clip = musicOptions[1];
                musicOrogin.Play();
                musicplaying = true;
            }
        }
        else
        {
            if(musicplaying == false)
            {
                musicOrogin.clip = musicOptions[0];
                musicOrogin.Play();
                musicplaying = true;
            }
        }
    }
}
