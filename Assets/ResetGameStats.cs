using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameStats : MonoBehaviour
{
    [SerializeField]
    GameStats gameStats;

    [SerializeField]
    List<Customer> customers = new List<Customer>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){
            gameStats.day = 1;
            gameStats.stats = new ResultsList();
            foreach (var customer in customers){
                customer.health = 100;
            }
            Destroy(gameObject);
        }
    }
}
