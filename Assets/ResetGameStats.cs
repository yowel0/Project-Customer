using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameStats : MonoBehaviour
{
    [SerializeField]
    GameStats gameStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){
            gameStats.day = 1;
            gameStats.stats = new ResultsList();
            Destroy(gameObject);
        }
    }
}
