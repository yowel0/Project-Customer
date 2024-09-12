using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CounterScript : MonoBehaviour
{

    public Slot vapeSlot;
    public Slot orderSlot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Compare(){
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

            print("Correct case: " + caseColor + "\r\n" + "Correct cap: " + capColor + "\r\n" + "Amount of wrong flavours: " + wrongFlavours + "\r\n" + "Nicotine Error: " + nicotineError);
        }
    }
}
