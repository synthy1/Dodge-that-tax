using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]

    public int dificulty;
    public float masterVolume;
    public float musicVolume;
    public bool beatEasy;
    public bool beatMedium;
    public bool beatHard;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
