using UnityEngine;
using UnityEngine.SceneManagement;

public class SManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
