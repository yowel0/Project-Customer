using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Vector3 startpos;
    Vector3 childStartpos;
    float ntimer;
    void Awake(){
        startpos = transform.localPosition;
        if (transform.childCount > 0){
            childStartpos = transform.GetChild(0).position;
        }
    }

    void Update(){
        if (ntimer < 0){
            transform.localPosition = startpos;
        }
        else{
            transform.localPosition = startpos + Vector3.down * .05f;
        }
        ntimer -= Time.deltaTime;
        if (transform.childCount > 0){
            transform.GetChild(0).position = childStartpos;
        }
    }

    public virtual void Interact(){
        ntimer = 0f;
    }
}
