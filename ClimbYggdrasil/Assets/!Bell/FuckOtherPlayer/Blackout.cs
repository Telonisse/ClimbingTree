using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Blackout : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] float time = 3f;

    public void BlackoutForP1()
    {
        StartCoroutine(BlackoutScreen(player1));
    }
    public void BlackoutForP2()
    {
        StartCoroutine(BlackoutScreen(player2));
    }

    IEnumerator BlackoutScreen(GameObject playerScreen)
    {
        Vector3 initial = playerScreen.transform.localScale;
        float elapsed = 0f;

        while (elapsed < 1)
        {
            playerScreen.transform.localScale = Vector3.Lerp(initial, Vector3.one, elapsed / 1);
            elapsed += Time.deltaTime;
            yield return null;
        }

        playerScreen.transform.localScale = Vector3.one;
        //playerScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        //playerScreen.SetActive(false);
        initial = playerScreen.transform.localScale;
        elapsed = 0f;
        while (elapsed < 1)
        {
            playerScreen.transform.localScale = Vector3.Lerp(initial, Vector3.zero, elapsed / 1);
            elapsed += Time.deltaTime;
            yield return null;
        }

        playerScreen.transform.localScale = Vector3.zero;
    }
}
