using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameScript : MonoBehaviour
{
    Workbench workbench;

    public Slider slider;
    RectTransform sliderTransform;
    public RectTransform pointer;
    public float pointerSpeed;
    public float missAddAmount = 0.05f;
    int misses = 0;
    // Start is called before the first frame update
    void Awake()
    {
        sliderTransform = slider.GetComponent<RectTransform>();
        workbench = FindAnyObjectByType<Workbench>();
                RelocateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        pointer.eulerAngles = new Vector3(0,0,pointer.eulerAngles.z + Time.deltaTime * pointerSpeed);
        if (pointer.eulerAngles.z <= -360){
            pointer.eulerAngles = pointer.eulerAngles + new Vector3(0,0,pointer.rotation.z + 360);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if (CheckHit()){
                workbench.Win(misses);
            }
            else{
                misses++;
                RelocateSlider(missAddAmount);
            }
        }
    }

    void RelocateSlider(float add = 0){
        slider.value += add;
        // sliderTransform.eulerAngles = new Vector3(0,0,Random.Range(-360 + slider.value * 360,0));
        sliderTransform.eulerAngles = new Vector3(0,0,Random.Range(0,360  - slider.value * 360));
    }

    bool CheckHit(){
        print(pointer.eulerAngles.z);
        print(sliderTransform.eulerAngles.z);
        print(sliderTransform.eulerAngles.z + slider.value * 360);
        if (pointer.eulerAngles.z >= sliderTransform.eulerAngles.z && pointer.eulerAngles.z <= sliderTransform.eulerAngles.z + slider.value * 360){
            return true;
        }
        return false;
    }
}
