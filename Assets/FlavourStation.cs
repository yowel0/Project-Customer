using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavourStation : MonoBehaviour
{
    public float fillTime;

    public Slot greenSlot;
    public Slot redSlot;
    public Slot blueSlot;

    float timer1;
    float timer2;
    float timer3;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    List<Slot> slots;
    List<float> timers;
    List<Slider> sliders;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>(){
            greenSlot,
            redSlot,
            blueSlot
        };
        timers = new List<float>(){
            timer1,
            timer2,
            timer3
        };
        sliders = new List<Slider>(){
            slider1,
            slider2,
            slider3
        };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slots.Count; i++){
            timers[i] = CheckSlot(slots[i],timers[i],sliders[i]);
        }
    }

    float CheckSlot(Slot slot, float timer, Slider slider){
        if (slot.itemHeld != null){
            if (timer == 0 && ContainsFlavour(slot)){
                return fillTime;
            }
            timer += Time.deltaTime;
        }
        else{
            timer = 0;
        }
        if (timer >= fillTime){
            if (slot.itemHeld != null){
                AddFlavourFromSlot(slot);
            }
        }
        slider.value = timer / fillTime;
        return timer;
    }

    void AddFlavourFromSlot(Slot slot){
        slot.itemHeld.GetComponent<VapeInfo>().AddFlavour(slot.transform.GetComponent<flavour>().type);
    }

    bool ContainsFlavour(Slot slot){
        if (slot.itemHeld.GetComponent<VapeInfo>().flavours.Contains(slot.transform.GetComponent<flavour>().type)){
            return true;
        }
        return false;
    }
}
