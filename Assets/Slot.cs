using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject itemHeld = null;
    public ItemScript.ItemType itemTypeRequirement;
    ItemPickup ip;
    SphereCollider sc;
    // Start is called before the first frame update
    void Start()
    {
        ip = GameObject.FindWithTag("Player").GetComponentInChildren<ItemPickup>();
        sc = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemHeld != null){
            itemHeld.transform.position = transform.position;
        }
    }

    void OnTriggerEnter (Collider collider){
        ItemScript item = collider.gameObject.GetComponent<ItemScript>();
        if (item != null){
            if (item.itemType == itemTypeRequirement){
                if (collider.gameObject.CompareTag("Item")){
                    if(ip.itemHeld == collider.gameObject){
                        ip.itemHeld = null;
                    }
                    itemHeld = collider.gameObject;
                    item.containingObject = gameObject;
                }
            }
        }
    }
}
