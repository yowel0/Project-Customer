using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : Outline
{
    public int selectedWidth;
    public int unSelectedWidth;

    int selected;

    public enum ItemType{
        Casing,
        Fillament,
        Cotton,
        Battery
    }

    public ItemType itemType = ItemType.Fillament;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (selected == 1){
            selected--;
        }
        else if (selected == 0){
            OutlineWidth = unSelectedWidth;
        }
    }

    public void Select(){
        OutlineWidth = selectedWidth;
        selected = 1;
    }
}
