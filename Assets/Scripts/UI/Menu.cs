using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene(){
        SceneManager.LoadScene("Main");
    }

    public void OpenCampaign(){
        Application.OpenURL("https://www.talkaboutvaping.org/");
    }

    public void ExitGame(){
        Application.Quit();
    }
}
