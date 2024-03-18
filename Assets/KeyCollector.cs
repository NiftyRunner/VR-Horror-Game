using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public bool isKeyCollectionComplete = false;

    [SerializeField] GameObject torch1;
    [SerializeField] GameObject torch2;
    [SerializeField] GameObject torch3;
    [SerializeField] int count = 0;
    [SerializeField] List<GameObject> Keys;

    void Start()
    {
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
        }

        if (count == 2) 
        {
            torch2.SetActive(true);
        }

        if (count == 3)
        {
            isKeyCollectionComplete = true;
            torch3.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Keys.Add(other.gameObject);
            count++;
        }
    }
}
