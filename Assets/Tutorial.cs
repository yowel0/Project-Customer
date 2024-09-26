using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameStats gameStats;

    public enum TutorialStage{
        acceptOrder,
        pickupCasing,
        fillNicotine,
        fillFlavours,
        putInCap,
        handIn,
        finished
    }
    public TutorialStage stage = TutorialStage.acceptOrder;

    public TextMeshProUGUI text;
    string tutorialbase = "Tutorial: \r\n";

    // Start is called before the first frame update
    void Start()
    {
        if (gameStats.day != 1){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage){
            case TutorialStage.acceptOrder:
            text.text = tutorialbase + "Press E on a customer to accept their order";
            break;
            case TutorialStage.pickupCasing:
            text.text = tutorialbase + "Press E on a case to pick it off the shelf, make sure to get the right color";
            break;
            case TutorialStage.fillNicotine:
            text.text = tutorialbase + "Put the case on the nicotine machine and hold E on the red button to fill it up to the right amount";
            break;
            case TutorialStage.fillFlavours:
            text.text = tutorialbase + "Put the case into the right slot of the flavour machine and wait a moment, you could use this time for other orders";
            break;
            case TutorialStage.putInCap:
            text.text = tutorialbase + "Now put the case on the workbench and put a mouthpiece down, then press the red button to combine them into a vape";
            break;
            case TutorialStage.finished:
            Destroy(gameObject);
            break;
        }
    }
}
