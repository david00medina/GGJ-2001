using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mirror: MonoBehaviour
{
    private GameObject thePlayer, theEnvironment;
    private Collider2D playerCollider;
    public GameObject mirrorEffect;
    public Animator activateCreditsDoor;

    public AudioClip pickupSound, sonarSound;
    public AudioSource audio;
    private DialogueQueue dialogueQueue;

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theEnvironment = GameObject.FindGameObjectWithTag("Environment");
        playerCollider = thePlayer.GetComponent<Collider2D>();
        dialogueQueue = gameObject.GetComponent<DialogueQueue>();
        audio = gameObject.GetComponent<AudioSource>(); //audio stuff
        StartCoroutine(AudioTimer());
        mirrorEffect.SetActive(false);
        activateCreditsDoor = GameObject.Find("Credits Door").GetComponent<Animator>();
    }



    private void Update()
    {

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


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Mirror collided with player");
            GameEvent.instance.DialogueQueue = dialogueQueue;

            audio.clip = pickupSound;
            audio.Play();
            mirrorEffect.SetActive(true);
            activateCreditsDoor.SetBool("MirrorReached", true); 
        }
    }


}
