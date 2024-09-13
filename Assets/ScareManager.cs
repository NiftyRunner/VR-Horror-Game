using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScareManager : MonoBehaviour
{
    [SerializeField] GameObject navGhostPrefab;
    [SerializeField] GameObject navGhost;
    [SerializeField] Transform player;
    [SerializeField] float minTime = 30f;
    [SerializeField] float maxTime = 100f;
    [SerializeField] float range = 3f;
    [SerializeField] float sceneChangeTime = 15f;
    [SerializeField] TextMeshProUGUI deadText;
    [SerializeField] TextMeshProUGUI collectionText;
    [SerializeField] LayerMask groundLayerMask;


    Vector3 randomPoint;
    //GameObject sanityMeter;

    [SerializeField] Slider slider;

    float randTime;
    public bool timeSelected = false;


    void Start()
    {
        //slider = sanityMeter.GetComponent<Slider>();
    }

    
    void Update()
    {
        if (!timeSelected)
        {
            Debug.Log("Time selected multiple");
            timeSelected = true;
            if(slider.value == 0)
            {
                randTime = 1;
            }
            else
            {
                randTime = Random.Range(minTime, maxTime);
            }
            
            Debug.Log("randtime is " + randTime);
            Invoke("SpawnScareAroundPlayer", randTime);
        }
    }

    void SpawnScareAroundPlayer()
    {

        if(slider.value == 0)
        {
            Vector3 position = Random.insideUnitSphere * range + player.position;
            randomPoint = new Vector3(position.x, player.position.y, 10f + position.z);
        }
        else
        {
            randomPoint = Random.insideUnitSphere * range + player.position;
        }
        //NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 100, groundLayerMask);
        //randomPoint = new Vector3(hit.position.x, randomPoint.y, hit.position.z);

        Debug.Log("randPoint is " + randomPoint);

        if (randomPoint.y > 0 && randomPoint.y < 100 && slider.value != 0)
        {
            navGhost.transform.position = randomPoint;
            navGhost.SetActive(true);
        }
        else if(randomPoint.y < 0 || randomPoint.y > 100 && slider.value != 0)
        {
            timeSelected = false;
        }
        else if(slider.value == 0)
        {
            collectionText.enabled = false;
            deadText.enabled = true;
            navGhost.transform.position = randomPoint;
            navGhost.SetActive(true);
            Instantiate(navGhostPrefab, randomPoint, Quaternion.identity);
            Invoke("MenuChange", sceneChangeTime);
        }
        
        //Invoke("StopAudio", clips[0].length);
    }

    void MenuChange()
    {
        SceneManager.LoadScene(0);
    }
}
