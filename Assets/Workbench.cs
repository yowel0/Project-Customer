using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public Slot caseSlot;
    public Slot capSlot;
    public PlayerMovement pm;
    public ItemPickup ip;
    public GameObject workbenchCanvas;
    private GameObject wbcInst;
    public Canvas canvas;
    public AudioSource craftSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(){
        if (caseSlot.itemHeld != null && capSlot.itemHeld != null){
            if (caseSlot.itemHeld.GetComponent<ItemScript>().itemType == ItemScript.ItemType.Casing && capSlot.itemHeld.GetComponent<ItemScript>().itemType == ItemScript.ItemType.Cap){
                ToggleWorkbenchMinigame();
            }
        }
    }

    public void ToggleWorkbenchMinigame(){
        if (Cursor.lockState == CursorLockMode.Locked){
            Cursor.lockState = CursorLockMode.Confined;
        }
        else{
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = !Cursor.visible;
        canvas.enabled = !canvas.enabled;
        TogglePlayerMovement();
        if (wbcInst == null){
            wbcInst = Instantiate(workbenchCanvas);
        }
        else {
            Destroy(wbcInst);
            wbcInst = null;
        }
    }

    public void TogglePlayerMovement(){
        pm.enabled = !pm.enabled;
        ip.enabled = !ip.enabled;
    }

    public void Win(int pMisses){
        ToggleWorkbenchMinigame();

        craftSound.Play();

        GameObject caseGo = caseSlot.itemHeld;
        GameObject cap = capSlot.itemHeld;
        caseGo.GetComponent<VapeInfo>().capMisses = pMisses;
        cap.transform.parent = caseSlot.itemHeld.transform;
        Destroy(capSlot.itemHeld.GetComponent<Rigidbody>());
        cap.GetComponent<ItemScript>().Release();
        cap.transform.localPosition = Vector3.zero;
        cap.tag = "Untagged";
        cap.layer = 0;
        caseGo.GetComponent<VapeInfo>().capColor = cap.GetComponent<CapScript>().capColor;
    }
}
