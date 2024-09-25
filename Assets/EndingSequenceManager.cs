using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingSequenceManager : MonoBehaviour
{
    public GameStats gameStats;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        if (text != null)
            text.text = gameStats.deaths.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void SkipToSequence2(){
        SceneManager.LoadScene("Ending Sequence 2");
    }

    public void VisitCampaign(){
        Application.OpenURL("https://www.talkaboutvaping.org/");
    }
}
