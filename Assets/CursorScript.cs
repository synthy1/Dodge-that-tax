using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{

    [Header("Refrences")]
    CharacterController player;

    [Header("inputs")]
    public KeyCode click1 = KeyCode.Mouse0;

    RectTransform cursorPosData;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterController>();

        cursorPosData = GetComponent<RectTransform>();
    }

    float mouseX = 0f;
    float mouseY = 0f;

    // Update is called once per frame
    void Update()
    {
        if (player.sitting)
        {
            mouseX = mouseX + (Input.GetAxis("Mouse X") * 0.001f);
            mouseY = mouseY + (Input.GetAxis("Mouse Y") * 0.001f);

            mouseX = Mathf.Clamp(mouseX, -0.011908f, 0.011908f);
            mouseY = Mathf.Clamp(mouseY, -0.005268f, 0.005268f);

            cursorPosData.anchoredPosition = new Vector3(mouseX, mouseY, transform.position.z);
        }
        //Debug.Log(cursorPosData.position);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "WebInt")
        {
            collision.GetComponent<WebInteractable>().Hover();

            if (Input.GetKey(click1))
            {
                collision.GetComponent<WebInteractable>().ClickedOn();
            }
        }
    }
}
