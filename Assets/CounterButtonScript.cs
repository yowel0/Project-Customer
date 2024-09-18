using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterButtonScript : Interactable
{
    public CounterScript counterScript;

    public override void Interact()
    {
        //base.Interact();
        counterScript.Click();
    }
}
