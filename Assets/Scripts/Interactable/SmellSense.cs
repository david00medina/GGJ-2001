using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellSense : MonoBehaviour
{
    [SerializeField] private List<GameObject> trackedObjects;
    private GameObject player;
    public AudioClip pickupSound;
    public AudioClip sonarSound;
    public AudioSource audio;
    private DialogueQueue diaglogueQueue;

    void Start()
    {
        diaglogueQueue = gameObject.GetComponent<DialogueQueue>();
        player = GameObject.FindWithTag("Player");
        audio = gameObject.GetComponent<AudioSource>(); //audio stuff
        StartCoroutine(AudioTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.HasSmell)
        {
            GameManager.Distance = Utility.MinimumDistance(player, trackedObjects);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Smell collided w player");
            GameEvent.instance.DialogueQueue = diaglogueQueue;
            GameManager.HasSmell = true;
            audio.clip = pickupSound; //more audio stuff
            audio.PlayOneShot(audio.clip);
        }
    }

    void RepeatAudioTimer() //Sets a timer for the audio to replay on
    {
        StartCoroutine(AudioTimer());
    }

    private IEnumerator AudioTimer()
    {
        AudioSource.PlayClipAtPoint(sonarSound, gameObject.transform.position);
        yield return new WaitForSeconds(5f);
        RepeatAudioTimer();
        yield return null;
    }
}