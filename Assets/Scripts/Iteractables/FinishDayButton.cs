using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDayButton : Interactable
{
    public DayCycleManager dayCycleManager;

    public override void Interact()
    {
        //base.Interact();
        dayCycleManager.FinishDay();
    }
}
