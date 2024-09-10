using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicotinizerButtonScript : Interactable
{
    public Nicotinizer nicotinizer;
    public override void Interact()
    {
        //base.Interact();
        nicotinizer.Fill();
    }
}
