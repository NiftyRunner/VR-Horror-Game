using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] float fadeDuration;
    [SerializeField] float outFade;
    [SerializeField] bool Fade = true;
    [SerializeField] public bool isPlaying = false;
    [SerializeField] bool playerInTrigger = false;
    
    float fadeByTime;


    private void Start()
    {
        playerInTrigger = false;
    }

    private void Update()
    {
        if (playerInTrigger == true)
        {
            fadeByTime = Time.deltaTime / fadeDuration;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerInTrigger = true;
        audioSource.volume = 1;
        fadeDuration = clip.length;
        if (other.gameObject.tag == "Player" && !isPlaying)
        {
            //Debug.Log("Player inside trigger");
            isPlaying = true;
            audioSource.PlayOneShot(clip);
            if(Fade)
            {
                Invoke("DelayBegin", 1f);   
            }
        }
    }

    private void DelayBegin()
    {
        //Debug.Log("Zone Audio");
        //Debug.Log("fade Duration is: " + fadeDuration);
        //Debug.Log("fade by time is: " + fadeByTime);
        StartCoroutine(FadeOutAudio(audioSource, fadeByTime));
    }

    void OnTriggerExit(Collider other)
    {
        fadeByTime = outFade;
        playerInTrigger = false;
        //isPlaying = false;
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0.0f)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0.0f, fadeByTime);
            startVolume = audioSource.volume;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = 1f;
        isPlaying = false;
    }
}
