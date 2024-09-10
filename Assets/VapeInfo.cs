using System.Collections.Generic;
using UnityEngine;

public class VapeInfo : MonoBehaviour
{
    public enum CasingColor{
        Blue,
        Green,
        Red
    }
    [Header("Color")]
    public CasingColor color;
    
    
    [Header("Flavour")]
    public List<flavour.FlavourType> flavours;

    public void AddFlavour(flavour.FlavourType flavour){
        if (!flavours.Contains(flavour)){
            flavours.Add(flavour);
        }
    }

    [Header("Nicotine")]
    [Range(0,100)]
    public float nicotine = 0;
}
