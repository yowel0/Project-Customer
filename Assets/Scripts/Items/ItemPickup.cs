using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    Transform cameraTransform;
    LayerMask mask;
    public GameObject itemHeld;
    public AudioSource audioSource;
    public AudioClip pickupSound;
    public AudioClip vapePickupSound;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        mask = LayerMask.GetMask("Item","Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        ItemRaycast();
        if (itemHeld != null){
            itemHeld.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            Rigidbody rb = itemHeld.GetComponent<Rigidbody>();
            if (rb != null){
                rb.velocity = Vector3.zero;
            }
            if (Input.GetKeyDown(KeyCode.Q)){
                itemHeld.GetComponent<ItemScript>().Release();
                itemHeld = null;
            }
            if (Input.GetKeyDown(KeyCode.G)){
                itemHeld.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500);
                itemHeld.GetComponent<ItemScript>().Release();
                itemHeld = null;
            }
        }
    }

    void ItemRaycast(){
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 10);
        RaycastHit hit;
        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward,out hit,1000f)){
            if (hit.collider.gameObject.CompareTag("Item")){
                OrderScript order = hit.collider.gameObject.GetComponent<OrderScript>();
                if (order != null){
                    //PlayerPopUp.NewPopUp(order.orderString(),0);
                }
                else {
                    PlayerPopUp.NewPopUp("E to Pick Up",0);
                }
                ItemScript item = hit.collider.gameObject.GetComponent<ItemScript>();
                if (item != null){
                    item.Select();
                }
                else{
                    print("This item has no Outline");
                }

                if (Input.GetKeyDown(KeyCode.E)){
                    item.Release();
                    itemHeld = hit.collider.gameObject;
                    item.containingObject = gameObject;
                    if (item.itemType == ItemScript.ItemType.Order){
                        PlaySound(pickupSound);
                    }
                    else{
                        PlaySound(vapePickupSound);
                    }
                }
            }
            if (hit.collider.gameObject.CompareTag("Interactable")){
                if (hit.collider.gameObject.GetComponent<FinishDayButton>()){
                    PlayerPopUp.NewPopUp("Finish Day",0);
                }
                else if (hit.collider.gameObject.GetComponent<NicotinizerButtonScript>()){
                    PlayerPopUp.NewPopUp("Hold E to Fill",0);
                }
                else{
                    PlayerPopUp.NewPopUp("Press E to Interact",0);
                }
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if (Input.GetKey(KeyCode.E)){
                    interactable.Interact();
                }
            }
            if (hit.collider.gameObject.CompareTag("Customer")){
                CustomerScript customer = hit.collider.gameObject.GetComponent<CustomerScript>();
                string customerName = customer.customer.name;
                PlayerPopUp.NewPopUp("Press E to Take " + customerName + "'s Order",0);
                if (Input.GetKeyDown(KeyCode.E)){
                    customer.Interact();
                }
            }
            
            if (hit.collider.gameObject.CompareTag("ToiletDoor")){
                PlayerPopUp.NewPopUp("Press E to Interact",0);
                ToiletDoor toiletDoor = hit.collider.gameObject.GetComponent<ToiletDoor>();
                if (Input.GetKeyDown(KeyCode.E)){
                    toiletDoor.Interact();
                }
            }
        }
    }

    void PlaySound(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
