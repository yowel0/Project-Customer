using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : Interactable
{
    public List<AudioSource> toiletSounds = new List<AudioSource>();
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
        foreach (AudioSource source in toiletSounds){
            source.volume = -(transform.position - playerTransform.position).magnitude * 1 / maxRange + 1;
        }
    }

    public override void Interact()
    {
        // base.Interact();
        int rand = Random.Range(0, toiletSounds.Count);
        toiletSounds[rand].Play();
    }
}
