using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    public DayCycleManager dayCycleManager;

    public GameObject customerPrefab;

    public List<Customer> todaysCustomers;

    public List<GameObject> instantiatedCustomers = new List<GameObject>();
    
    public List<GameObject> leavingCustomers = new List<GameObject>();

    public Transform spawnPoint;
    public Transform queuePoint;

    public float moveSpeed;

    public AudioSource bell;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SetCustomerPositions();
        if (todaysCustomers.Count == 0 && instantiatedCustomers.Count == 0 && leavingCustomers.Count == 0){
            dayCycleManager.FinishDay();
        }
    }

    void FixedUpdate(){
        MoveToPosition();
    }

    public void InstantiateNextCustomer(){
        if (todaysCustomers.Count > 0){
            InstantiateCustomer(todaysCustomers[0]);
            todaysCustomers.RemoveAt(0);
        }
    }

    public void RemoveCustomer(CustomerScript customerScript){
        instantiatedCustomers.Remove(customerScript.gameObject);
        leavingCustomers.Add(customerScript.gameObject);
        //Destroy(customerScript.gameObject);
    }

    void InstantiateCustomer(Customer customer){
        bell.Play();
        customerPrefab.GetComponent<CustomerScript>().customer = customer;
        instantiatedCustomers.Add(Instantiate(customerPrefab,spawnPoint.position,new quaternion(0,180,0,0)));
    }

    void SetCustomerPositions(){
        for(int i = 0; i < instantiatedCustomers.Count; i++){
            instantiatedCustomers[i].transform.position = queuePoint.position + new Vector3(i,0,0);
            instantiatedCustomers[i].transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    void MoveToPosition(){
        for(int i = 0; i < instantiatedCustomers.Count; i++){
            if ((queuePoint.position + new Vector3(i,0,0) - instantiatedCustomers[i].transform.position).magnitude <= moveSpeed){
                instantiatedCustomers[i].transform.position = queuePoint.position + new Vector3(i,0,0);
                if (instantiatedCustomers[i].transform.GetChild(0).GetComponent<Animator>()){
                    Animator animator = instantiatedCustomers[i].transform.GetChild(0).GetComponent<Animator>();
                    animator.SetBool("Walking",false);
                }
            }
            else{
                instantiatedCustomers[i].transform.position += (queuePoint.position + new Vector3(i,0,0) - instantiatedCustomers[i].transform.position).normalized * moveSpeed;
                if (instantiatedCustomers[i].transform.GetChild(0).GetComponent<Animator>()){
                    Animator animator = instantiatedCustomers[i].transform.GetChild(0).GetComponent<Animator>();
                    animator.SetBool("Walking",true);
                }
            }
            //instantiatedCustomers[i].transform.eulerAngles = new Vector3(0,180,0);
        }
        for(int i = 0; i < leavingCustomers.Count; i++){
            if ((spawnPoint.position - leavingCustomers[i].transform.position).magnitude <= moveSpeed){
                Destroy(leavingCustomers[i]);
                leavingCustomers.RemoveAt(i);
            }
            else{
                leavingCustomers[i].transform.position += (spawnPoint.position - leavingCustomers[i].transform.position).normalized * moveSpeed;
                if (leavingCustomers[i].transform.GetChild(0).GetComponent<Animator>()){
                    Animator animator = leavingCustomers[i].transform.GetChild(0).GetComponent<Animator>();
                    animator.SetBool("Walking",true);
                }
            }
        }
    }
}
