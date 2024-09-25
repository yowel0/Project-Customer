using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intermission : MonoBehaviour
{
    public GameStats gameStats;
    public CustomerSequence customerSequence;
    public TextMeshProUGUI header;
    public TextMeshProUGUI text;
    public TextMeshProUGUI dayCountText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI didYouKnowText;

    public List<String> dykTextList;


    float capscore = 0;
    float nicotinescore = 0;
    float flavourscore = 0;
    float casingscore = 0;
    float totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        header.text = "Day " + gameStats.day + " Recap";

        text.text = "";

        // if (gameStats.stats.resultsList[gameStats.day - 1].results.Count <=0) 
        //     print(gameStats.LatestDayOrders().results.Count);

        // for (int i = 0; i < gameStats.LatestDayOrders().results.Count; i++){
        //     OrderResults orderResults = gameStats.LatestDayOrders().results[i];
        //     //if (orderResults != null)
        //     text.text += "Order " + (i+1) + " Score: " + orderResults.orderScore + "\r\n";
        // }

        for (int i = 0; i < gameStats.LatestDayOrders().results.Count; i++){
            OrderResults orderResults = gameStats.LatestDayOrders().results[i];
            //if (orderResults != null)
            //text.text += "Order " + (i+1) + " Score: " + orderResults.orderScore + "\r\n";
            capscore += orderResults.capScore;
            nicotinescore += orderResults.nicotineScore;
            flavourscore += orderResults.flavourScore;
            casingscore += orderResults.caseScore;

            totalScore += (orderResults.capScore + orderResults.nicotineScore + orderResults.flavourScore + orderResults.caseScore) / 4;
        }
        capscore = capscore / gameStats.LatestDayOrders().results.Count;
        nicotinescore = Mathf.Round(nicotinescore / gameStats.LatestDayOrders().results.Count);
        flavourscore = Mathf.Round(flavourscore / gameStats.LatestDayOrders().results.Count);
        casingscore = Mathf.Round(casingscore / gameStats.LatestDayOrders().results.Count);
        totalScore = Mathf.Round(totalScore / gameStats.LatestDayOrders().results.Count);
        text.text += capscore + "\r\n" + "\r\n" + nicotinescore + "\r\n" + "\r\n" + flavourscore + "\r\n" + "\r\n" + casingscore;

        didYouKnowText.text = dykTextList[UnityEngine.Random.Range(0, dykTextList.Count)];
        totalScoreText.text = totalScore.ToString();
        dayCountText.text = gameStats.day.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueNextDay(){
        if (gameStats.day == 5){
            SceneManager.LoadScene("Ending Sequence 1");
        }
        else{
            bool noCustomers = true;
            foreach(Customer customer in customerSequence.customerSequence.days[gameStats.day].customers){
                if (customer.health > 0){
                    noCustomers = false;
                }
            }
            if (noCustomers){
                SceneManager.LoadScene("Ending Sequence 0");
            }
            else{
                gameStats.day++;
                SceneManager.LoadScene("Main");
            }
        }
    }
}
