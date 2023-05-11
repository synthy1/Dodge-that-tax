using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCall : MonoBehaviour
{

    public TimerScript time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time.gameStartl)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
