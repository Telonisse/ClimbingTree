using UnityEngine;
using UnityEngine.SceneManagement;

public class Hammer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            //SceneManager.LoadScene(2);
        }
    }
}
