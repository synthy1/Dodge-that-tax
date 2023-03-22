using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{

    [Header("Refrences")]
    CharacterController player;
    public Image Cursor;

    [Header("inputs")]
    public KeyCode click1 = KeyCode.Mouse0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
