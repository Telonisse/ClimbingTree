using UnityEngine;

public class BlackoutBall : Powerup
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            FindFirstObjectByType<Blackout>().BlackoutForP2();
            FindFirstObjectByType<AudioManager>().Play("Blackout");
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            FindFirstObjectByType<Blackout>().BlackoutForP1();
            FindFirstObjectByType<AudioManager>().Play("Blackout");
            Destroy(this.gameObject);
        }
    }
}
