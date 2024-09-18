using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer Sequence")]
public class CustomerSequence : ScriptableObject
{
    public DaysList customerSequence = new DaysList();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class DaySequence{
    public List<Customer> customers;
}

[Serializable]
public class DaysList{
    public List<DaySequence> days;
}
