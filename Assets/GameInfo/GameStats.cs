using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStats", menuName = "GameStats")]
public class GameStats : ScriptableObject
{
    public int day;

    //public ResultList stats = new ResultList();
    //public List<List<OrderResults>> stats = new List<List<OrderResults>>();
    public ResultsList stats = new ResultsList();

    public void AddResult(OrderResults orderResults){
        if (stats.resultsList.Count < day){
            stats.resultsList.Add(new Results());
        }
        stats.resultsList[day - 1].results.Add(orderResults);
        //stats.resultsList[day - 1].results.Add(orderResults);
    }

    public OrderResults LatestDayOrder(int index){
        return stats.resultsList[day - 1].results[index];
    }
    
    public Results LatestDayOrders(){
        return stats.resultsList[day - 1];
    }
}


[Serializable]
public class Results{
    public List<OrderResults> results = new List<OrderResults>();
}

[Serializable]
public class ResultsList{
    public List<Results> resultsList = new List<Results>();
}
