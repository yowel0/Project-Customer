using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTmanager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips = new List<AudioClip>();
    public GameStats gameStats;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clips[gameStats.day - 1];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
