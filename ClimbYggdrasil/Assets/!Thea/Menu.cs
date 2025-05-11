using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        FindFirstObjectByType<AudioManager>().Play("Select");
        SceneManager.LoadScene(5);
    }

    public void Credits()
    {
        FindFirstObjectByType<AudioManager>().Play("Select");
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        FindFirstObjectByType<AudioManager>().Play("Select");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        FindFirstObjectByType<AudioManager>().Play("Select");
        Application.Quit();
        Debug.Log("you turned off the game silly billy");
    }

}
