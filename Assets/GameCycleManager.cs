using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public List<Customer> todaysCustomers = new List<Customer>();

    [SerializeField]
    List<GameObject> instantiatedCustomers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetCustomerPositions();

        if (Input.GetKeyDown(KeyCode.P)){
            InstantiateCustomer(todaysCustomers[0]);
            todaysCustomers.RemoveAt(0);
        }
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
