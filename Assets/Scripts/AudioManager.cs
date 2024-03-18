using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{

    [SerializeField] GameObject audioSourceForRange;
    [SerializeField] Transform audioHolder;
    [SerializeField] Transform player;
    [SerializeField] float range = 3f;
    [SerializeField] float minTime = 30f;
    [SerializeField] float maxTime = 100f;
    [SerializeField] float fadeDuration = 0.1f;
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();

    GameObject sanityMeter;

    Slider slider;
    
    float audioVolume;
    int clipRef;
    float randTime;
    bool timeSelected = false;

    private void Start()
    {
        sanityMeter = GameObject.FindGameObjectWithTag("Meter");
        slider = sanityMeter.GetComponent<Slider>();
        audioSourceForRange.transform.position = audioHolder.position;
    }

    void Update()
    {
        if(!timeSelected)
        {
            timeSelected = true;
            randTime = Random.Range(minTime, maxTime);
            //Debug.Log(randTime);
            Invoke("StartSource", randTime);
        }
        
    }

    void StartSource()
    {
        //Debug.Log("Start Source");
        clipRef = Random.Range(0, clips.Count);
        //Debug.Log(clipRef);
        SpawnSourceAroundPlayer(clips[clipRef]);
    }

    float SetVolume()
    {
        if(slider.value <= 0.15)
        {
            audioVolume = 1;
        }
        else
        {
            audioVolume = Random.Range(0.3f, 1f);
        }
        return audioVolume;

    }

    void SpawnSourceAroundPlayer(AudioClip clip)
    {
        SetVolume();
        //Debug.Log(clip);
        //Debug.Log("clip playing");
        Vector3 randomPoint = Random.insideUnitSphere * range + player.position;
        //Debug.Log(randomPoint);
        audioSourceForRange.transform.position = randomPoint;
        audioSourceForRange.GetComponent<AudioSource>().volume = audioVolume;
        audioSourceForRange.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1f);
        audioSourceForRange.GetComponent<AudioSource>().PlayOneShot(clip);
        Invoke("StopAudio", clips[0].length);
    }

    void StopAudio()
    {
        //StartCoroutine(FadeOutAudio(audioSourceForRange.GetComponent<AudioSource>(), fadeDuration));
        audioSourceForRange.GetComponent<AudioSource>().Stop();
        audioSourceForRange.transform.position = audioHolder.position;
        timeSelected = false;
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0.0f)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0.0f, Time.deltaTime / fadeDuration);
            startVolume = audioSource.volume;
            yield return null;
        }
        audioSource.Stop();
    }
}
