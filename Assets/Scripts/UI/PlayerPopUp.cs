using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerPopUp : MonoBehaviour
{
    private static PlayerPopUp instance;

    static List<PopUp> popUps = new List<PopUp>();

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (popUps.Count > 0){
            text.text = popUps[0].text;
            popUps[0].time -= Time.deltaTime;
            if (popUps[0].time <= 0){
                popUps.RemoveAt(0);
            }
        }
        else{
            text.text = "";
        }
    }

    public static void NewPopUp(string pText, float pTime){
        popUps.Add(new PopUp(pText, pTime));
    }
}

class PopUp{
    public string text;
    public float time;

    public PopUp(string pText, float pTime){
        text = pText;
        time = pTime;
    }
}
