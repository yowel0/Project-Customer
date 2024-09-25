using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    Transform playerTransform;
    public float maxRange;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = -(transform.position - playerTransform.position).magnitude * 1 / maxRange + 1;
    }

    public void PlaySound(AudioClip pAudioClip){
        audioSource.clip = pAudioClip;
        audioSource.Play();
    }

    public void PlaySoundFromList(List<AudioClip> pAudioClips){
        if (pAudioClips.Count > 0){
            PlaySound(pAudioClips[Random.Range(0,pAudioClips.Count)]);
        }
    }
}
