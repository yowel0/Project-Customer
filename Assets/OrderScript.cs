using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    public Customer customer;

    List<VapeInfo.CasingColor> possibleCasingColors;
    List<flavour.FlavourType> possibleFlavourTypes;
    public VapeInfo.CasingColor caseColor;
    public VapeInfo.CasingColor capColor;
    public List<flavour.FlavourType> flavours;
    public float nicotine;

    // Start is called before the first frame update
    void Awake()
    {
        if (customer == null){
            GenerateOrder();
        }
        else if(customer != null){
            GenerateCustomerOrder();
        }
        print("AWAK");

    }

    void GenerateOrder(){
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

        nicotine = Random.Range(0,5) * 25;

        int flavourAmount = Random.Range(1,4);
        for (int i = 0; i < flavourAmount; i++){
            int rand = Random.Range(0, possibleFlavourTypes.Count);
            flavours.Add(possibleFlavourTypes[rand]);
            possibleFlavourTypes.RemoveAt(rand);
        }
    }

    void GenerateCustomerOrder(){
        caseColor = customer.casingColors[Random.Range(0,customer.casingColors.Count())];
        capColor = customer.capColors[Random.Range(0,customer.capColors.Count())];

        nicotine = customer.nicotineValues[Random.Range(0,customer.nicotineValues.Count())];

        int flavourAmount = Random.Range(1,customer.maxFlavourAmount + 1);
        possibleFlavourTypes = new List<flavour.FlavourType>(customer.flavourTypes);
        for (int i = 0; i < flavourAmount; i++){
            int rand = Random.Range(0, possibleFlavourTypes.Count);
            flavours.Add(possibleFlavourTypes[rand]);
            possibleFlavourTypes.RemoveAt(rand);
        }
    }

    public string orderString(){
        string standard = "Case color:  " + caseColor + "\r\n" +
        "Cap color: " + capColor + "\r\n" +
        "Nicotine: " + nicotine + "\r\n";
        if (flavours.Count == 1){
        return standard +
        "Flavours: " + flavours[0];
        }
        if (flavours.Count == 2){
        return standard +
        "Flavours: " + flavours[0] + "\r\n" +
        flavours[1];
        }
        if (flavours.Count == 3){
        return standard +
        "Flavours: " + flavours[0] + "\r\n" +
        flavours[1] + "\r\n" +
        flavours[2];
        }
        return standard;
    }
}
