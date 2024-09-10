using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    Transform cameraTransform;
    LayerMask mask;
    GameObject itemHeld;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        mask = LayerMask.GetMask("Item");
    }

    // Update is called once per frame
    void Update()
    {
        ItemRaycast();
        if (itemHeld != null){
            itemHeld.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            itemHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Q)){
                itemHeld = null;
            }
            if (Input.GetKeyDown(KeyCode.G)){
                itemHeld.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500);
                itemHeld = null;
            }
        }
    }

    void ItemRaycast(){
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 10);
        RaycastHit hit;
        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward,out hit,1000f,mask)){
            ItemScript outline = hit.collider.gameObject.GetComponent<ItemScript>();
            if (outline != null){
                outline.Select();
            }
            else{
                print("This item has no Outline");
            }

            if (Input.GetKeyDown(KeyCode.E)){
                itemHeld = hit.collider.gameObject;
            }
        }
    }
}
