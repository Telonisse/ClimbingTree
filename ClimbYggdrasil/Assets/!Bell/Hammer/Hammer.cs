using UnityEngine;
using UnityEngine.SceneManagement;

public class Hammer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
        if (other.tag == "P2")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
