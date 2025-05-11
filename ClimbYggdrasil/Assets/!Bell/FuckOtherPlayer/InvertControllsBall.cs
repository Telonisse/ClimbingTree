using System.Linq;
using UnityEngine;

public class InvertControllsBall : Powerup
{
    PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            FindFirstObjectByType<AudioManager>().Play("Pickup");
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 1);
            playerMovement.InvertControlls();
            FindFirstObjectByType<AudioManager>().Play("Invert");
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            FindFirstObjectByType<AudioManager>().Play("Pickup");
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 0);
            playerMovement.InvertControlls();
            FindFirstObjectByType<AudioManager>().Play("Invert");
            Destroy(this.gameObject);
        }
    }
}
