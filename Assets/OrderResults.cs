using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderResults : MonoBehaviour
{
    bool caseColor = false;
    bool capColor = false;
    int capMisses = 0;
    int wrongFlavours = 0;
    float nicotineError = 0;

    public float caseScore = 0;
    public float capScore = 0;
    public float flavourScore = 0;
    public float nicotineScore = 0;

    public float orderScore;
    public OrderResults(bool pCaseColor, bool pCapColor, int pCapMisses, int pWrongFlavours, float pNicotineError){
        caseColor = pCapColor;
        capColor = pCapColor;
        capMisses = pCapMisses;
        wrongFlavours = pWrongFlavours;
        nicotineError = pNicotineError;
        CalculateOrderScore();
    }

    void CalculateOrderScore(){
        if (caseColor)
            caseScore = 100 - capMisses * 10;
        if (capColor)
            capScore = 100 - capMisses * 10;
        flavourScore = Mathf.Clamp(100 - 50 * (float)wrongFlavours,0,100);
        nicotineScore = Mathf.Clamp(100f - Mathf.Round(nicotineError * 5),0,100);

        orderScore = (caseScore + capScore + flavourScore + nicotineScore) / 4;
    }

    void PrintDetails(){
        print("Correct case: " + caseColor + "\r\n" + "Correct cap: " + capColor + "\r\n" + "Amount of wrong flavours: " + wrongFlavours + "\r\n" + "Nicotine Error: " + nicotineError);
    }

    public override string ToString()
    {
        return "Order Score: " + orderScore;
    }
}
