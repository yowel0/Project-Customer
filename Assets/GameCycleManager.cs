using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public List<Customer> todaysCustomers;

    public List<GameObject> instantiatedCustomers = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetCustomerPositions();

        if (Input.GetKeyDown(KeyCode.P)){
            InstantiateNextCustomer();
        }
    }

    public void InstantiateNextCustomer(){
        if (todaysCustomers.Count > 0){
            InstantiateCustomer(todaysCustomers[0]);
            todaysCustomers.RemoveAt(0);
        }
    }

    public void RemoveCustomer(CustomerScript customerScript){
        instantiatedCustomers.Remove(customerScript.gameObject);
        Destroy(customerScript.gameObject);
    }

    void InstantiateCustomer(Customer customer){
        customerPrefab.GetComponent<CustomerScript>().customer = customer;
        instantiatedCustomers.Add(Instantiate(customerPrefab));
    }

    void SetCustomerPositions(){
        for(int i = 0; i < instantiatedCustomers.Count; i++){
            instantiatedCustomers[i].transform.position = new Vector3(19.15f,0,1.3f + i);
            instantiatedCustomers[i].transform.eulerAngles = new Vector3(0,180,0);
        }
    }
}
