using UnityEngine;

public class PStandingScare_a : MonoBehaviour
{
    [SerializeField] GameObject wicthModel;
    [SerializeField] AudioClip scareClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Collider triggerCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(scareClip);
            Invoke("witchDeactivate", 0.5f);
            //wicthModel.SetActive(false);
            //triggerCollider.enabled = false;
        }
    }

    void witchDeactivate()
    {
        wicthModel.SetActive(false);
        triggerCollider.enabled = false;
    }
}