using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().SetBool("End", true);
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        FindFirstObjectByType<AudioManager>().Play("Boom1");
        FindFirstObjectByType<AudioManager>().Play("Boom2");
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
