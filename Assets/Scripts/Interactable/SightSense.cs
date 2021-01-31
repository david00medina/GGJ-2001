using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class SightSense: MonoBehaviour
{
    private GameObject thePlayer, theManager, theEnvironment;
    private CharacterController2D charControl2D_Script;

    [SerializeField] private float OuterRadioWithSight, OuterRadioWithout = 3.31f;
    private DialogueQueue diaglogueQueue;
    
    private Light2D sightLight, globalLight;
    private Collider2D playerCollider;

    public AudioClip pickupSound, sonarSound;
    public AudioSource audio;

    void Start()
    {
        diaglogueQueue = gameObject.GetComponent<DialogueQueue>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theEnvironment = GameObject.FindGameObjectWithTag("Environment");
        sightLight = thePlayer.GetComponentInChildren<Light2D>();
        globalLight = theEnvironment.GetComponentInChildren<Light2D>();
        charControl2D_Script = thePlayer.GetComponent<CharacterController2D>();
        playerCollider = thePlayer.GetComponent<Collider2D>();
        audio = gameObject.GetComponent<AudioSource>(); //audio stuff
        StartCoroutine(AudioTimer());
    }



    void Update()
    {
        LightBHV();
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



    //Disables the Player Point Light
    private void LightsOff()
    {
        sightLight.enabled = false;
    }

    //Checks if grounded and turns lights on or of.
   private void GroundedLight(bool grounded, float airSight)
    {
        if (grounded == false)
        {
            Invoke("LightsOff", airSight);
        } else
        {
            sightLight.enabled = true;
        }
    }

    private void LightBHV()
    {
        GroundedLight(charControl2D_Script.m_Grounded, charControl2D_Script.airSight);
        if (!GameManager.HasSight)
        {
            sightLight.pointLightOuterRadius = OuterRadioWithout;
            globalLight.enabled = false;
        }
        if (GameManager.HasSight)
        {
            sightLight.pointLightOuterRadius = OuterRadioWithSight;
            //sightLight.enabled = false;
            globalLight.enabled = false;
        }
    }


	
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Sight collided with player");
            GameManager.HasSight = true;
            GameEvent.instance.DialogueQueue = diaglogueQueue;
            audio.clip = pickupSound;
            audio.Play();
        }
    }
}
