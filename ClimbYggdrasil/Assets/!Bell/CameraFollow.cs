using System.ComponentModel;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool shouldShake;
    [SerializeField] Camera cam;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset;

    [SerializeField] Vector3 shakeAmount;
    [SerializeField] AnimationCurve shakePower;
    [SerializeField] float shakeSpeed;
    float shakeTime;
    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 shakeOffset = Vector3.zero;
        if (shouldShake)
        {
            shakeTime = Mathf.MoveTowards(shakeTime, 1, shakeSpeed * Time.fixedDeltaTime);
            shakeOffset = shakeAmount * shakePower.Evaluate(shakeTime);
            if (shakeTime >= 1)
            {
                shakeTime = 0;
                shouldShake = false;
            }
        }

        Vector3 targetPos = player.transform.position + offset;
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, targetPos, ref velocity, speed) + shakeOffset;
    }


    public void Shake()
    {
        shouldShake = true;
    }

}
