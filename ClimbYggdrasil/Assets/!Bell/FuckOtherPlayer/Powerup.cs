using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private bool isCatchup = false;

    public bool IsCatchup { get => isCatchup;  }
}
