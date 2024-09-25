using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : Outline
{
    private int selectedWidth = 10;
    private int unSelectedWidth = 2;

    int selected;

    public enum ItemType{
        Casing,
        Cap,
        Order
    }

    public ItemType itemType;

    public GameObject containingObject;

    Rigidbody rb;

    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (selected == 1){
            selected--;
        }
        else if (selected == 0){
            OutlineWidth = unSelectedWidth;
        }

        if (containingObject != null){
            if (rb != null){
                rb.velocity = Vector3.zero;
            }
            if (itemType == ItemType.Casing || itemType == ItemType.Cap){
                if (containingObject.CompareTag("Player")){
                    transform.eulerAngles = containingObject.transform.eulerAngles + new Vector3(0,-90,0);
                }
                else{
                    transform.eulerAngles = containingObject.transform.eulerAngles + new Vector3(0,90,0);
                }
            }
            else if(itemType == ItemType.Order){
                if (containingObject.CompareTag("Player")){
                    transform.eulerAngles = containingObject.transform.eulerAngles + new Vector3(0,0,0);
                }
                else{
                    transform.eulerAngles = containingObject.transform.eulerAngles + new Vector3(0,180,0);
                }
            }
        } 
    }

    public void Select(){
        OutlineWidth = selectedWidth;
        selected = 1;
    }

    public void Release(){
        if (containingObject != null){
            if (containingObject.GetComponent<ItemPickup>()){
                containingObject.GetComponent<ItemPickup>().itemHeld = null;
            }
            if(containingObject.GetComponent<Slot>()){
                containingObject.GetComponent<Slot>().itemHeld = null;
            }
        }
        containingObject = null;
    }
}
