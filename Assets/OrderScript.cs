using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class OrderScript : MonoBehaviour
{

    List<VapeInfo.CasingColor> possibleCasingColors;
    List<flavour.FlavourType> possibleFlavourTypes;
    public VapeInfo.CasingColor caseColor;
    public VapeInfo.CasingColor capColor;
    public List<flavour.FlavourType> flavours;
    public float nicotine;

    // Start is called before the first frame update
    void Awake()
    {
        possibleCasingColors = new List<VapeInfo.CasingColor>(){
            VapeInfo.CasingColor.Blue,
            VapeInfo.CasingColor.Green,
            VapeInfo.CasingColor.Red
        };
        possibleFlavourTypes = new List<flavour.FlavourType>(){
            flavour.FlavourType.Watermelon,
            flavour.FlavourType.Blueberry,
            flavour.FlavourType.Strawberry
        };
        caseColor = possibleCasingColors[Random.Range(0,3)];
        capColor = possibleCasingColors[Random.Range(0,3)];
        nicotine = Random.Range (1,5) * 25;

        int flavourAmount = Random.Range(1,4);
        for (int i = 0; i < flavourAmount; i++){
            int rand = Random.Range(0, possibleFlavourTypes.Count);
            flavours.Add(possibleFlavourTypes[rand]);
            possibleFlavourTypes.RemoveAt(rand);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string orderString(){
        return "Case color:  " + caseColor + "\r\n" +
        "Cap color: " + capColor + "\r\n" +
        "Nicotine: " + nicotine + "\r\n" +
        "Flavours: ";
    }
}
