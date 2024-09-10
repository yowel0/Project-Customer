using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nicotinizer : MonoBehaviour
{
    public Slot slot;
    [Tooltip("Amount of nicotine per second")]
    public float fillSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill(){
        if (slot.itemHeld != null){
            VapeInfo vapeInfo = slot.itemHeld.GetComponent<VapeInfo>();
            vapeInfo.nicotine += Time.deltaTime * fillSpeed;
            if(vapeInfo.nicotine > 100){
                vapeInfo.nicotine = 100;
            }
            print ( vapeInfo.nicotine);
        }
    }
}
