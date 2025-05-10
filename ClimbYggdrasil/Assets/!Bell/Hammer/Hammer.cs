using UnityEngine;
using UnityEngine.SceneManagement;

public class Hammer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            SceneManager.LoadScene(3);
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            SceneManager.LoadScene(4);
            Destroy(this.gameObject);
        }
    }
}
