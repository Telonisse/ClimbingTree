using System.Linq;
using UnityEngine;

public class ShakeOtherCamera : Powerup
{
    PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            FindFirstObjectByType<AudioManager>().Play("Pickup");
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 1);
            playerMovement.transform.parent.GetComponentInChildren<CameraFollow>().StartShake();
            FindFirstObjectByType<AudioManager>().Play("Shake");
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            FindFirstObjectByType<AudioManager>().Play("Pickup");
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 0);
            playerMovement.transform.parent.GetComponentInChildren<CameraFollow>().StartShake();
            FindFirstObjectByType<AudioManager>().Play("Shake");
            Destroy(this.gameObject);
        }
    }

}
