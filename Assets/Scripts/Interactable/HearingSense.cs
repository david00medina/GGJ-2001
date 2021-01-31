using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HearingSense : MonoBehaviour
{
    private GameObject thePlayer, theManager, theEnvironment, theSight, theMirror, theSmell;
    private Collider2D playerCollider;
    public AudioClip pickupSound, sonarSound;
    public AudioSource audioHearing, audioSight, audioMirror, audioSmell;
    public AudioMixerSnapshot hearingSnapshot;
    public float hearingSnapshotTransitionTime = 20f;
    private DialogueQueue diaglogueQueue;

    void Start()
    {
        //GameObject Finders
        theManager = GameObject.FindGameObjectWithTag("GameManager");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theEnvironment = GameObject.FindGameObjectWithTag("Environment");
        theSight = GameObject.FindGameObjectWithTag("Sight");
        theMirror = GameObject.FindGameObjectWithTag("Mirror");
        theSmell = GameObject.FindGameObjectWithTag("Smell");
        
        // Dialogues
        diaglogueQueue = gameObject.GetComponent<DialogueQueue>();

        //Colliders
        playerCollider = thePlayer.GetComponent<Collider2D>();
        
        //audio 
        audioHearing = gameObject.GetComponent<AudioSource>();
        audioSight = theSight.GetComponent<AudioSource>();
        audioMirror = theMirror.GetComponent<AudioSource>();
        audioSmell = theSmell.GetComponent<AudioSource>();

        StartCoroutine(AudioTimer());
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

    void Update()
    {
        SenseBehaviour();
    }

    //Sense Behaviour
    private void SenseBehaviour()
    {
        if (!GameManager.HasHearing)
        {
            audioHearing.mute = true;
            audioSight.mute = true;
            audioSmell.mute = true;
            audioMirror.mute = true;
        }
        if (GameManager.HasHearing == true)
        {
            audioHearing.mute = false;
            audioSight.mute = false;
            audioSmell.mute = false;
            audioMirror.mute = false;
        }
    }


    //Triger Behaviour
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hearing collided with player");
            GameManager.HasHearing = true;
            GameEvent.instance.DialogueQueue = diaglogueQueue;

            audioHearing.clip = pickupSound;
            audioHearing.Play();

            hearingSnapshot.TransitionTo(hearingSnapshotTransitionTime);
        }
    }
}