using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]

    int dificulty;
    float masterVolume;
    float musicVolume;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
