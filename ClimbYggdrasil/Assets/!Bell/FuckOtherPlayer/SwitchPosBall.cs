using System.Linq;
using UnityEngine;

public class SwitchPosBall : Powerup
{
    GameObject player1;
    GameObject player2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1" || other.tag == "P2")
        {
            var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);

            player2 = players.FirstOrDefault(m => m.GetPlayerIndex() == 1).gameObject;
            player1 = players.FirstOrDefault(m => m.GetPlayerIndex() == 0).gameObject;

            Vector3 p1Pos = player1.transform.position;
            Vector3 p2Pos = player2.transform.position;

            player1.transform.position = p2Pos;
            player2.transform.position = p1Pos;

            FindFirstObjectByType<AudioManager>().Play("Switch");
            Destroy(this.gameObject);
        }
    }
}
