using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepSystem : MonoBehaviour
{
    [SerializeField] InputActionProperty moveAction;

    [SerializeField] AudioSource source;

    [SerializeField] AudioClip moveClip;

    RaycastHit hit;
    
    [SerializeField] Transform rayStart;
    [SerializeField] float range;
    [SerializeField] LayerMask layerMask;

    [SerializeField] bool isMoving = false;

    private void Update()
    {
        Vector2 actionValue = moveAction.action.ReadValue<Vector2>();
        if(actionValue != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public void Footsteps()
    {
        if(Physics.Raycast(rayStart.position, rayStart.transform.up * -1, out hit, range, layerMask))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("ground") && isMoving)
            {
                Debug.Log("PlaySoundNow");
                PlayFootStepSound(moveClip);
            }
        }
    }

    void PlayFootStepSound(AudioClip clip)
    {
        source.pitch = Random.Range(0.8f, 1f);
        source.PlayOneShot(clip);
    }
}
