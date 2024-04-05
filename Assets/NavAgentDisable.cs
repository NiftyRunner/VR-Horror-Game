using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavAgentDisable : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] ScareManager scareManager;
    [SerializeField] GameObject agent;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "ghost")
    //    {
    //        Debug.Log("Triggered");
    //        scareManager.timeSelected = false;
    //        m_AudioSource.PlayOneShot(audioClip);
    //        agent.SetActive(false);

    //    }
    //}
}
