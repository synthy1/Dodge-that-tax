using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBoxes : MonoBehaviour
{

    public BuyButton buy;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(buy.timeToClickAmmount == 0)
        {
            Instantiate(box);
        }
    }
}
