using System.Linq;
using UnityEngine;

public class FreezeBall : Powerup
{
        PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            FindFirstObjectByType<AudioManager>().Play("Pickup");
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 1);
            playerMovement.FreezePlayer();
            FindFirstObjectByType<AudioManager>().Play("Freeze");
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            FindFirstObjectByType<AudioManager>().Play("Pickup");
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 0);
            playerMovement.FreezePlayer();
            FindFirstObjectByType<AudioManager>().Play("Freeze");
            Destroy(this.gameObject);
        }
    }
}
