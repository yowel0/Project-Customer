using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : Interactable
{
    public Customer customer;
    public GameObject order;

    GameObject currentOrder;
    // Start is called before the first frame update
    void Awake()
    {
        LoadModel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadModel(){
        Instantiate(customer.Model, transform);
    }

    public override void Interact()
    {
        //base.Interact();
        GenerateOrder();
    }

    void GenerateOrder(){
        if (currentOrder != null){
            Destroy(currentOrder);
        }
        order.GetComponent<OrderScript>().customer = customer;
        currentOrder = Instantiate(order, transform.position + Vector3.up * 2, transform.rotation);
    }
}
