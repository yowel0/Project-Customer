using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Nicotinizer : MonoBehaviour
{
    public Slot slot;
    [Tooltip("Amount of nicotine per second")]
    public float fillSpeed;
    public Slider slider;
    public Gradient gradient;
    VapeInfo vapeInfo;
    public Image fill;
    public AudioSource audioSource;
    public AudioClip hold;

    private float oldNicotine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slot.itemHeld == null){
            slider.value = 0;
        }
        else {
            vapeInfo = slot.itemHeld.GetComponent<VapeInfo>();
            slider.value = vapeInfo.nicotine /100;
            fill.color = gradient.Evaluate(slider.value);
        }
    }

    public void Fill(){
        if (slot.itemHeld != null){
            if (vapeInfo.nicotine == 0){
                PlaySound(hold);
            }
            vapeInfo.nicotine += Time.deltaTime * fillSpeed;
            if(vapeInfo.nicotine > 100){
                vapeInfo.nicotine = 100;
            }
            oldNicotine = vapeInfo.nicotine;
        }
    }

    void PlaySound(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
