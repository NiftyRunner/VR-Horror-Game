// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction;
using UnityEngine.XR;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;


public class InventoryVR : MonoBehaviour
{
    [SerializeField] Transform invetoryHolder;
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;
    bool isUIAway;

    private void Start()
    {
        Debug.Log(gameObject.name);
        Inventory.transform.position = invetoryHolder.transform.position;
        isUIAway = true;
        //Inventory.SetActive(false);
        UIActive = false;


        XRIDefaultInputActions inputActions = new XRIDefaultInputActions();
        inputActions.XRILeftHandInteraction.Enable();
        inputActions.XRILeftHandInteraction.ToggleInventory.performed += ToggleInventory_performed;
    }

    private void ToggleInventory_performed(InputAction.CallbackContext obj)
    {
        if (isUIAway == false)
        {
            Inventory.transform.position = invetoryHolder.transform.position;
            isUIAway = true;
            UIActive = false;
        }
        else if(isUIAway == true)
        {
            Inventory.transform.position = Anchor.transform.position;
            isUIAway = false;
            UIActive = true;
        }
        
        //UIActive = !UIActive;
        //Inventory.SetActive(UIActive);
    }

    private void Update()
    {
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}
