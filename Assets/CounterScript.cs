using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public GameCycleManager gameCycleManager;

    public GameStats gameStats;

    public Slot vapeSlot;
    public Slot orderSlot;

    CustomerSoundManager customerSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        customerSoundManager = GameObject.FindWithTag("CustomerSoundManager").GetComponent<CustomerSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        Compare();
        if (vapeSlot.itemHeld != null && orderSlot.itemHeld != null){
            gameCycleManager.RemoveCustomer(orderSlot.itemHeld.GetComponent<OrderScript>().customerScript);
            orderSlot.itemHeld.GetComponent<OrderScript>().customer.health -= Mathf.RoundToInt(vapeSlot.itemHeld.GetComponent<VapeInfo>().nicotine);
            customerSoundManager.PlaySoundFromList(orderSlot.itemHeld.GetComponent<OrderScript>().customer.exitSounds);
            Destroy(orderSlot.itemHeld);
            Destroy(vapeSlot.itemHeld);
        }
    }

    void Compare(){
        if (vapeSlot.itemHeld != null && orderSlot.itemHeld != null){
            VapeInfo vapeInfo = vapeSlot.itemHeld.GetComponent<VapeInfo>();
            OrderScript orderScript = orderSlot.itemHeld.GetComponent<OrderScript>();

            bool caseColor = false;
            bool capColor = false;
            int wrongFlavours = 0;
            float nicotineError = 0;

            if (vapeInfo.caseColor == orderScript.caseColor){
                caseColor = true;
            }
            if (vapeInfo.capColor == orderScript.capColor){
                capColor = true;
            }
            for (int i = 0; i < vapeInfo.flavours.Count; i++){
                if (!orderScript.flavours.Contains(vapeInfo.flavours[i])){
                    wrongFlavours++;
                }
            }
            for (int i = 0; i < orderScript.flavours.Count; i++){
                if (!vapeInfo.flavours.Contains(orderScript.flavours [i])){
                    wrongFlavours++;
                }
            }
            nicotineError = Mathf.Abs(vapeInfo.nicotine - orderScript.nicotine);
            OrderResults orderResults = new OrderResults(caseColor,capColor,vapeInfo.capMisses,wrongFlavours,nicotineError);
            gameStats.AddResult(orderResults);
            print(gameStats.stats.resultsList[gameStats.day - 1].results[gameStats.stats.resultsList[gameStats.day - 1].results.Count-1]); 
            //print("Correct case: " + caseColor + "\r\n" + "Correct cap: " + capColor + "\r\n" + "Amount of wrong flavours: " + wrongFlavours + "\r\n" + "Nicotine Error: " + nicotineError);
        }
    }
}
