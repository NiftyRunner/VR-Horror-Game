using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour
{
    public GameObject itemInSlot;
    public Image slotImage;

    Grabbable grabbable;
    bool triggerValue;
    InputDevice device;

    bool isColliding = false;

    private void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        grabbable = FindFirstObjectByType<Grabbable>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(itemInSlot != null) { return; }
        GameObject obj = other.gameObject;
        if(!IsItem(obj)) { return; }
        
        //if(grabbable.isDropped == true)
        //{
        //    InsertItem(obj);
        //    grabbable.isDropped = false;
        //}

        //if (grabbable.isGrabbed == true)
        //{
        //    ReleaseItem(obj);
        //    grabbable.isGrabbed = false;
        //}

    }


    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        itemInSlot = obj;
    }

    //void ReleaseItem(GameObject obj)
    //{
    //    obj.GetComponent<Rigidbody>().isKinematic = false;
    //    obj.transform.SetParent(gameObject.transform, false);
    //    obj.transform.localPosition = Vector3.one;
    //    obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
    //    obj.GetComponent<Item>().inSlot = false;
    //    obj.GetComponent<Item>().currentSlot = null;
    //    itemInSlot = obj;
    //}
}
