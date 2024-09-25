using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Vector3 startpos;
    Vector4 childStartpos;
    float ntimer;
    void Start(){
        startpos = transform.localPosition;
        if (transform.childCount > 0){
            childStartpos = transform.GetChild(0).position;
        }
    }

    void Update(){
        if (ntimer < 0){
            transform.localPosition = startpos;
        }
        ntimer -= Time.deltaTime;
        if (transform.childCount > 0){
            transform.GetChild(0).position = childStartpos;
        }
    }

    public virtual void Interact(){
        transform.localPosition = startpos + Vector3.down * .05f;
        ntimer = 0;
    }
}
