using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrap : MonoBehaviour
{
    [SerializeField] GameObject jumpScareTrigger;

    private void OnTriggerEnter(Collider other)
    {
        jumpScareTrigger.SetActive(true);
    }
}
