using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCycleManager : MonoBehaviour
{
    public GameCycleManager gameCycleManager;
    public GameStats gameStats;
    public CustomerSequence customerSequence;

    public float dayLength = 15;
    public float dayTimer;
    private float spawnLength;
    private float spawnTimer;

    private List<Customer> todaysCustomers = new List<Customer>();

    bool dayStarted = false;
    bool dayEnded = false;
    bool dayFinished = false;
    // Start is called before the first frame update
    void Awake()
    {
        StartDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (dayStarted && !dayEnded){
            dayTimer -= Time.deltaTime;
            if (dayTimer <= 0){
                EndDay();
            }
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0){
                spawnTimer += spawnLength;
                gameCycleManager.InstantiateNextCustomer();
            }
        }
    }

    void StartDay(){
        dayStarted = true;
        dayTimer = dayLength;
        todaysCustomers = new List<Customer>(customerSequence.customerSequence.days[gameStats.day-1].customers);
        spawnLength = dayLength / todaysCustomers.Count;
        spawnTimer = spawnLength;
        gameCycleManager.todaysCustomers = todaysCustomers;
        gameCycleManager.InstantiateNextCustomer();
    }

    void EndDay(){
        dayEnded = true;
        dayTimer = 0;
    }

    public void FinishDay(){
        if (dayEnded && gameCycleManager.instantiatedCustomers.Count <= 0){
            dayFinished = true;
            SceneManager.LoadScene("Intermission");
        }
    } 
}
