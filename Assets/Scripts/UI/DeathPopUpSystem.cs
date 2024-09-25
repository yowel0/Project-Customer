using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DeathPopUpSystem : MonoBehaviour
{
    public CustomerSequence customerSequence;
    public GameStats gameStats;
    public GameObject popUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Customer customer in customerSequence.customerSequence.days[gameStats.day - 1].customers){
            if(customer.health <=0 && customer.health > -200){
                customer.health = -200;
                gameStats.deaths++;
                GameObject inst = Instantiate(popUpPrefab,transform);
                inst.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = customer.sprite;
                inst.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = customer.name + " died";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
