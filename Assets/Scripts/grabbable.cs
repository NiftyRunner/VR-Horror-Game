using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbable : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    public bool isDropped = false;
    public bool isGrabbed = false;

    [SerializeField] GameObject inventory;

    [SerializeField] XRSocketInteractor[] slots;
    [SerializeField] Transform slot;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");

        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectExited.AddListener(OnItemDrop);

        grabInteractable.selectEntered.AddListener(OnItemGrab);
    }

    void OnItemGrab(SelectEnterEventArgs arg0)
    {
        isGrabbed = true;
        isDropped = false;

        //if (gameObject.GetComponent<Item>() == null) { return; }
        //if (gameObject.GetComponent<Item>().inSlot)
        //{
        //    Debug.Log("Is in slot");
        //    Transform parentSlot = gameObject.GetComponentInParent<Transform>();
        //    gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //    gameObject.GetComponentInParent<Slot>().itemInSlot = null;
        //    gameObject.transform.SetParent(parentSlot, false);
        //    gameObject.transform.parent = null;
        //    gameObject.GetComponent<Item>().inSlot = false;
        //    gameObject.GetComponent<Item>().currentSlot = null;

        //}
    }

    void OnItemDrop(SelectExitEventArgs eventArgs)
    {
        isDropped = true;
        isGrabbed = false;

        bool isInventory = false;
        //foreach (var slot in slots)
        //{
        //    IXRSelectInteractable obj = slot.GetOldestInteractableSelected();
        //    print(obj.transform.name);
        //    if(gameObject.name == obj.transform.name)
        //    {
        //        Debug.Log("hmm");
        //        isInventory = true;
        //        gameObject.transform.SetParent(inventory.transform, false);
        //        break;
        //    }
            
        //}
        //gameObject.transform.SetParent(null);

        gameObject.transform.SetParent(slot.transform, false);
        

    }

    

}
