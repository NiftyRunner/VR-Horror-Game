using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] float spawnDistance = 2f;
    [SerializeField] GameObject menu;
    [SerializeField] InputActionProperty rShowButton;


    void Update()
    {
        if (rShowButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        menu.transform.forward *= -1;

    }

}
