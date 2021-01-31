using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{

    public AudioSource bgmAudioSource;
    public AudioClip bgm;
    public float fadeDuration = 2f;

    // Update is called once per frame

    private void Start()
    {
        bgmAudioSource.clip = bgm;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag =="Player")
        {
            bgmAudioSource.Play();
            StartCoroutine(FadeAudioSource.StartFade(bgmAudioSource, fadeDuration, 1f));
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FadeAudioSource.StartFade(bgmAudioSource, fadeDuration, 0f));
        }
    }
}
