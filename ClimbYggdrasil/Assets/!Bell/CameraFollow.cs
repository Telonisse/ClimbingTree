using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset;

    [SerializeField] float shakeAmount;
    [SerializeField] float shakeDuration;
    Vector3 shakeOffset = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = player.transform.position + offset;
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, targetPos, ref velocity, speed) + shakeOffset;
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * shakeAmount;
            float yOffset = Random.Range(-0.5f, 0.5f) * shakeAmount;

            shakeOffset = new Vector3(xOffset, yOffset, 0);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        shakeOffset = Vector3.zero;
    }
}
