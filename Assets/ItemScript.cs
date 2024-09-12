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
        Cap
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
            transform.rotation = originalRotation;
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
