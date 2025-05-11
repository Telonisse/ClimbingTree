using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public GameObject meo; 

    private void Start()
    {
        StartCoroutine(count());
    }
    IEnumerator count()
    {
        yield return new WaitForSecondsRealtime(4);
        meo.SetActive(false);
        numberText.gameObject.SetActive(true);
        numberText.text = "3";
        FindFirstObjectByType<AudioManager>().Play("CountDown");
        yield return new WaitForSecondsRealtime(1);
        FindFirstObjectByType<AudioManager>().Play("CountDown");
        numberText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        FindFirstObjectByType<AudioManager>().Play("CountDown");
        numberText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        FindFirstObjectByType<AudioManager>().Play("Duuu");

        SceneManager.LoadScene(1);
    }
}
