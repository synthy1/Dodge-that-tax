using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public TimerScript time;
    AudioSource musicOrogin;
    public AudioClip[] musicOptions;

    bool countdownMode = false;
    void Start()
    {
        musicOrogin = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if ((time.timer < 45f) && !countdownMode)
        {
            musicOrogin.Stop();
            countdownMode = true;
        }

        if (!countdownMode)
        {
            if (musicOrogin.isPlaying == false)
            {
                musicOrogin.clip = musicOptions[0];
                musicOrogin.Play();
            }
        }

        if (countdownMode)
        {
            if (musicOrogin.isPlaying == false)
            {
                musicOrogin.clip = musicOptions[1];
                musicOrogin.Play();
            }
        }

        /*if(time.timer <= 45 && time.gameStartl)
        {
            musicOrogin.Stop();

            if (musicOrogin.isPlaying == false)
            {
                musicOrogin.clip = musicOptions[1];
                musicOrogin.Play();
            }
        }
        else
        {
            if(musicOrogin.isPlaying == false && time.timer > 45)
            {
                musicOrogin.clip = musicOptions[0];
                musicOrogin.Play();
            }
        }*/
    }
}
