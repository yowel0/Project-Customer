using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intermission : MonoBehaviour
{
    public GameStats gameStats;
    public TextMeshProUGUI header;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        header.text = "Day " + gameStats.day + " Recap";

        text.text = "";

        // if (gameStats.stats.resultsList[gameStats.day - 1].results.Count <=0) 
        //     print(gameStats.LatestDayOrders().results.Count);

        for (int i = 0; i < gameStats.LatestDayOrders().results.Count; i++){
            OrderResults orderResults = gameStats.LatestDayOrders().results[i];
            //if (orderResults != null)
            text.text += "Order " + (i+1) + " Score: " + orderResults.orderScore + "\r\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueNextDay(){
        gameStats.day++;
        SceneManager.LoadScene("Main");
    }
}
