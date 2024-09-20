using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Customer Name", menuName = "Customer")]
public class Customer : ScriptableObject
{
    public int health = 100;
    public GameObject Model;
    public GameObject Model2;
    public GameObject Model3;

    public VapeInfo.CasingColor[] casingColors;
    public VapeInfo.CasingColor[] capColors;

    public float[] nicotineValues;

    public int maxFlavourAmount;
    public flavour.FlavourType[] flavourTypes;
}
