using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollector : MonoBehaviour
{
    public bool isKeyCollectionComplete = false;

    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject torch1;
    [SerializeField] AudioSource torch1_Source;
    [SerializeField] GameObject torch2;
    [SerializeField] AudioSource torch2_Source;
    [SerializeField] GameObject torch3;
    [SerializeField] AudioSource torch3_Source;
    [SerializeField] int count = 0;
    [SerializeField] List<GameObject> Keys;

    [SerializeField] float changeTime = 3f;

    bool isKey1Collected = false;
    bool isKey2Collected = false;
    bool isKey3Collected = false;

    void Start()
    {
        isKey1Collected = false;
        isKey2Collected = false;
        isKey3Collected = false;

        torch1.SetActive(false);
        torch2.SetActive(false);
        torch3.SetActive(false);
        isKeyCollectionComplete = false;
    }

    private void Update()
    {
        if (count == 1)
        {
            torch1.SetActive(true);
            torch1_Source.Play();
            
        }

        if (count == 2)
        {
            torch2.SetActive(true);
            torch2_Source.Play();
        }

        if (count == 3)
        {
            isKeyCollectionComplete = true;
            torch3.SetActive(true);
            torch3_Source.Play();
            FinishSequence();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key1" && isKey1Collected == false)
        {
            isKey1Collected=true;
            Keys.Add(other.gameObject);
            count++;
        }
        if (other.gameObject.tag == "Key2" && isKey2Collected == false)
        {
            isKey2Collected=true;
            Keys.Add(other.gameObject);
            count++;
        }
        if (other.gameObject.tag == "Key3" && isKey3Collected == false)
        {
            isKey3Collected=true;
            Keys.Add(other.gameObject);
            count++;
        }
    }

    private void FinishSequence()
    {
        audioSource.Play();
        Invoke("FinalSceneChange", changeTime);
    }

    void FinalSceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
