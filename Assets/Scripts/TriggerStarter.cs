using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerStarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Start")
        {
            Debug.Log("Start Trigger");
            SceneManager.LoadScene(1);
        }

        if (other.gameObject.tag == "Quit")
        {
            Application.Quit();
        }

        if (other.gameObject.tag == "Menu")
        {
            SceneManager.LoadScene(0);
        }
        //if(other.gameObject.tag == "Hand")
        //{
        //    Debug.Log("Start Trigger");
        //    SceneManager.LoadScene(1);
        //}
    }
}
