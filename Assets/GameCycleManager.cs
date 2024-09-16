using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public Customer customer1;
    public Customer customer2;

    // Start is called before the first frame update
    void Start()
    {
        // InstantiateCustomer(customer1);
        // InstantiateCustomer(customer2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateCustomer(Customer customer){
        customerPrefab.GetComponent<CustomerScript>().customer = customer;
        Instantiate(customerPrefab);
    }
}
