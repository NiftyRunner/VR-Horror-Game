using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHandler : MonoBehaviour
{
    public bool isCollectionComplete = false;

    [SerializeField] GameObject closeChest;
    [SerializeField] GameObject openChest;
    [SerializeField] int count = 0;
    [SerializeField] List<GameObject> Objects;

    void Start()
    {
        closeChest.SetActive(true);
        openChest.SetActive(false);
        isCollectionComplete = false;
    }

    private void Update()
    {
        if(count == 3)
        {
            isCollectionComplete = true;
            openChest.SetActive(true);
            closeChest.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectionObject")
        {
            Objects.Add(other.gameObject);
            count++;
        }
    }
}
