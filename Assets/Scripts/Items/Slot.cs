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

    public GameObject holoCapPrefab;
    public GameObject holoCasePrefab;
    public GameObject holoOrderPrefab;

    private GameObject inst;

    // Start is called before the first frame update
    void Start()
    {
        ip = GameObject.FindWithTag("Player").GetComponentInChildren<ItemPickup>();
        sc = gameObject.GetComponent<SphereCollider>();
        switch (itemTypeRequirement){
            case ItemScript.ItemType.Cap:
            inst = Instantiate(holoCapPrefab, transform);
            inst.transform.eulerAngles += new Vector3(0, 90,0);
            break;
            case ItemScript.ItemType.Casing:
            inst = Instantiate(holoCasePrefab, transform);
            inst.transform.eulerAngles += new Vector3(0, 90,0);
            break;
            case ItemScript.ItemType.Order:
            inst = Instantiate(holoOrderPrefab, transform);
            inst.transform.eulerAngles += new Vector3(0, 180,0);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (itemHeld != null){
            if (inst != null)
                inst.SetActive(false);
            itemHeld.transform.position = transform.position;
        }
        else{
            if (inst != null)
                inst.SetActive(true);
        }
    }

    void OnTriggerEnter (Collider collider){
        if (itemHeld == null){
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
}
