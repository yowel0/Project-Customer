using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.O)){
            Interact();
        }
    }

    public virtual void Interact(){
        print("Interact111");
    }
}
