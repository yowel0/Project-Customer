using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Customer Name", menuName = "Customer")]
public class Customer : ScriptableObject
{
    public GameObject Model;

    public VapeInfo.CasingColor[] casingColors;
    public VapeInfo.CasingColor[] capColors;

    public float[] nicotineValues;

    public int maxFlavourAmount;
    public flavour.FlavourType[] flavourTypes;
}
