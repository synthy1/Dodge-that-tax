using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    int tutorialStep = 0;

    [Header("refrences")]
    public Text tutorialText;
    public PhoneQTE phone;
    public WifeQTE wife;
    public Chair chair;
    public DoshScript dosh;
    public TimerScript time;
    CharacterController player;

    [Header("Bools")]
    [SerializeField] bool hasSat;
    [SerializeField] bool hasPhone;
    [SerializeField] bool hasWife;
    [SerializeField] bool hasWifi;
    [SerializeField] bool hasBought;
    [SerializeField] bool hasMoved;
    [SerializeField] bool hasStarted;
    public bool hasInteractedWithPhone = false;

    [Header("float")]
    float startingDosh;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialStep)
        {
            case 0:
                if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !hasMoved)
                {
                    Debug.Log("tuturial text 1");
                    tutorialText.text = "Press W,A,S,D to move!";

                }
                else
                {
                    hasMoved = true;
                    tutorialText.text = null;
                    tutorialStep++;
                }
                break;

            case 1:
                if (!time.gameStartl && !hasStarted)
                {
                    Debug.Log("tuturial text 2");
                    tutorialText.text = "Press E on the PC tower to start DOGING THAT TAX!";
                }
                else
                {
                    hasStarted = true;
                    startingDosh = dosh.dosh;
                    tutorialText.text = null;
                    tutorialStep++;
                }
                break;

            case 2:
                if (!player.sitting && !hasSat)
                {
                    Debug.Log("tuturial text 3");
                    tutorialText.text = "Press E on the chair to sit at the desk AND S while sitting to get up!";
                }
                else
                {
                    hasSat = true;
                    tutorialText.text = null;
                    tutorialStep++;
                }
                break;

            case 3:
                if (dosh.dosh == startingDosh && !hasBought)
                {
                    Debug.Log("tuturial text 4");
                    tutorialText.text = "Press BUY or BID when the text is green";
                }
                else
                {
                    hasBought = true;
                    tutorialText.text = null;
                    tutorialStep++;
                }
                break;

            case 4:
                if (hasInteractedWithPhone == false)
                {
                    if (phone.active)
                    {
                        Debug.Log("If ran");
                        tutorialText.text = "Press E on the phone to hang up";
                    }
                }
                else
                {
                    Debug.Log("else ran");
                    hasPhone = true;
                    tutorialText.text = null;
                    tutorialStep++;
                }
                break;

            case 5:
                 if(wife.stopWife == false)
                 {

                    if (wife.active)
                    {
                        tutorialText.text = "Press F on money and give her the alomony";
                    }
                 }

                 else
                 {
                    Debug.Log("end tutorial");
                    hasWife = true;
                    tutorialText.text = null;
                    tutorialStep++;
                 }
                break;

                /*if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !hasMoved)
                {
                    Debug.Log("tuturial text 1");
                    tutorialText.text = "Press W,A,S,D to move!";
                }
                else
                {
                    hasMoved = true;
                    tutorialText.text = null;
                }

                else if (!player.sitting && !hasSat)
                {
                    Debug.Log("tuturial text 2");
                    tutorialText.text = "Press E on the chair to sit at the desk!";
                }
                else
                {
                    hasSat = true;
                    tutorialText.text = null;
                }

                else if(dosh.dosh == startingDosh  && !hasBought)
                {
                    Debug.Log("tuturial text 3");
                    tutorialText.text = "Press BUY or BID when the text is green";
                }
                else
                {
                    hasBought = true;
                    tutorialText.text = null;
                }

                else if(wife.active && !hasWife)
                {
                    Debug.Log("tuturial text 4");
                    tutorialText.text = "Press F on money and give her the alomony";
                }
                else
                {
                    hasWife = true;
                    tutorialText.text = null;
                }

                else if(phone.active && !hasPhone)
                {
                    Debug.Log("tuturial text 5");
                    tutorialText.text = "Press E on the phone to hang up";
                }
                else
                {
                    hasPhone = true;
                    tutorialText.text = null;
                }*/
        }
    }
}
