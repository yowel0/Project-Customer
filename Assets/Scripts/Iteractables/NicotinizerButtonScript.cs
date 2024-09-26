using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicotinizerButtonScript : Interactable
{
    public Nicotinizer nicotinizer;
    Tutorial tutorial;

    void Start(){
        if (GameObject.Find("Tutorial") != null)
            tutorial = GameObject.Find("Tutorial").GetComponent<Tutorial>();
    }

    public override void Interact()
    {
        if (tutorial != null){
            if (tutorial.stage == Tutorial.TutorialStage.fillNicotine){
                tutorial.stage = Tutorial.TutorialStage.fillFlavours;
            }
        }
        base.Interact();
        nicotinizer.Fill();
    }
}
