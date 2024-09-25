using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchCanvasButtonScript : MonoBehaviour
{
    Workbench workbench;
    // Start is called before the first frame update
    void Awake()
    {
        workbench = FindObjectOfType<Workbench>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        workbench.ToggleWorkbenchMinigame();
    }
}
