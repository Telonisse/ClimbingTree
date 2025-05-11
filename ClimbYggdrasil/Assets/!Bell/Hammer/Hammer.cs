using UnityEngine;
using UnityEngine.SceneManagement;

public class Hammer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            FindFirstObjectByType<AudioManager>().Play("Hammer");
            SceneManager.LoadScene(3);
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            FindFirstObjectByType<AudioManager>().Play("Hammer");
            SceneManager.LoadScene(4);
            Destroy(this.gameObject);
        }
    }
}
