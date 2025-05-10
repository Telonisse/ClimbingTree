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
        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene(0);
    }
}
