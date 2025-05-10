using System.Linq;
using UnityEngine;

public class FreezeBall : Powerup
{
        PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 1);
            playerMovement.FreezePlayer();
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
            playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == 0);
            playerMovement.FreezePlayer();
            Destroy(this.gameObject);
        }
    }
}
