using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : Interactable
{
    public Customer customer;
    public GameObject order;

    CustomerSoundManager customerSoundManager;

    GameObject currentOrder;

    float timer;
    bool timerStarted;
    Tutorial tutorial;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("Tutorial") != null)
            tutorial = GameObject.Find("Tutorial").GetComponent<Tutorial>();
        customerSoundManager = GameObject.FindWithTag("CustomerSoundManager").GetComponent<CustomerSoundManager>();
        LoadModel();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted){
            timer -= Time.deltaTime;
            print(timer);
            if (timer <= 0){
                timerStarted = false;
                customerSoundManager.PlaySoundFromList(customer.randomSounds);
                print("Raondmondsoudnd)");
            }
        }
    }

    void LoadModel(){
        if(customer.health > 50)
            Instantiate(customer.Model, transform);
        else if (customer.health <= 50 && customer.health > 30)
            Instantiate(customer.Model2, transform);
        else if (customer.health <= 30)
            Instantiate(customer.Model3, transform);
    }

    public override void Interact()
    {
        //base.Interact();
        GenerateOrder();
    }

    void GenerateOrder(){
        if (tutorial != null){
            if (tutorial.stage == Tutorial.TutorialStage.acceptOrder){
                tutorial.stage = Tutorial.TutorialStage.pickupCasing;
            }
        }
        customerSoundManager.PlaySoundFromList(customer.orderSounds);
        StartTimerVoiceline();
        if (currentOrder == null){
            order.GetComponent<OrderScript>().customer = customer;
            order.GetComponent<OrderScript>().customerScript = this;
            currentOrder = Instantiate(order, transform.position + Vector3.up * 2, order.transform.rotation);
        }
        else{
            currentOrder.GetComponent<ItemScript>().Release();
            currentOrder.transform.position = transform.position + Vector3.up * 2;
        }
    }

    void StartTimerVoiceline(){
        timer = Random.Range(5f,10f);
        timerStarted = true;
    }
}
