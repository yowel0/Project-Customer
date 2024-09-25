using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchButtonScript : Interactable
{
    public Workbench workbench;
    public override void Interact()
    {
        base.Interact();
        workbench.Hit();
    }
}