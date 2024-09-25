using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : Interactable
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
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

    public override void Interact()
    {
        // base.Interact();
        int rand = Random.Range(0, audioClips.Count);
        PlaySound(audioClips[rand]);
    }

    void PlaySound(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
