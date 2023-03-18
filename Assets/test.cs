using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : Interactable
{
    public override void OnFocus()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInteract()
    {
        Debug.Log("interactexd");
    }

    public override void OnLoseFocus()
    {
        throw new System.NotImplementedException();
    }

}
