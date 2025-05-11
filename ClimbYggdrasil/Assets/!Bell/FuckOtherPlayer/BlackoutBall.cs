using UnityEngine;

public class BlackoutBall : Powerup
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            FindFirstObjectByType<AudioManager>().Play("Blackout");
            FindFirstObjectByType<Blackout>().BlackoutForP2();
            Destroy(this.gameObject);
        }
        if (other.tag == "P2")
        {
            FindFirstObjectByType<AudioManager>().Play("Blackout");
            FindFirstObjectByType<Blackout>().BlackoutForP1();
            Destroy(this.gameObject);
        }
    }
}
