using UnityEngine;

public class VRButton : MonoBehaviour
{
    [SerializeField] float pressDepth = 0.01f;
    [SerializeField] float pressedTime = 10.0f;
    [SerializeField] bool objectiveButton = false;
    [SerializeField] PuzzleHandler puzzleHandler;
    
    private bool isPressed = false;
    bool isCountInreased = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isPressed = false;
            Invoke("OnButtonRelease", pressedTime);

        }
    }

    private void Update()
    {
        if (isPressed)
        {
            transform.localPosition = new Vector3(initialPosition.x, initialPosition.y - pressDepth, initialPosition.z); // Move button down on press
            OnButtonPressed();
        }
    }

    private void OnButtonPressed()
    {
        if (objectiveButton)
        {
            IncreaseCount();
        }
        Debug.Log("Button Pressed");
    }

    void OnButtonRelease()
    {
        transform.localPosition = initialPosition;
        if (objectiveButton)
        {
            DecreaseCount();
        }
        Debug.Log("Button Released");
    }

    private void IncreaseCount()
    {
        if(!isCountInreased)
        {
            puzzleHandler.pCount += 1;
            isCountInreased = true;
        }
    }

    void DecreaseCount()
    {
        if(puzzleHandler.pCount > 0)
        {
            puzzleHandler.pCount -= 1;
            isCountInreased = false;
        }
    }
}
