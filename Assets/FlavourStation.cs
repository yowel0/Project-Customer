using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavourStation : MonoBehaviour
{
    public Slot greenSlot;
    public Slot redSlot;
    public Slot blueSlot;

    float timer1;
    float timer2;
    float timer3;

    List<Slot> slots;
    List<float> timers;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>(){
            greenSlot,
            blueSlot,
            redSlot
        };
        timers = new List<float>(){
            timer1,
            timer2,
            timer3
        };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slots.Count; i++){
            timers[i] = CheckSlot(slots[i],timers[i]);
        }
    }

    float CheckSlot(Slot slot, float timer){
        if (slot.itemHeld != null){
            timer += Time.deltaTime;
        }
        else{
            timer = 0;
        }
        if (timer >= 5){
            if (slot.itemHeld != null){
                AddFlavourFromSlot(slot);
            }
        }
        return timer;
    }

    void AddFlavourFromSlot(Slot slot){
        slot.itemHeld.GetComponent<VapeInfo>().AddFlavour(slot.transform.GetComponent<flavour>().type);
    }
}
