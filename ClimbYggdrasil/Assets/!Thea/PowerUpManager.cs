using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private List<Powerup> m_powerups = new List<Powerup>();
    [SerializeField] private float m_catchupDistance = 10;

    private List<PlayerInput> m_players = new List<PlayerInput>();

    public void OnPlayerJoined(PlayerInput input)
    {
        m_players.Add(input);
    }

    public void OnPlayerLeft(PlayerInput input)
    {
        m_players.Remove(input);
    }


    [ContextMenu("Find")]
    private void FindObjects()
    {
        m_powerups = FindObjectsByType<Powerup>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
    }

    private void Update()
    {
        if (m_players == null)
            return;

        if (m_powerups == null)
            return;

        m_powerups = m_powerups.Where(x => x != null).ToList();

        foreach (var powerup in m_powerups)
        {
            if (!powerup.IsCatchup)
                continue;

            float highestPlayer = 0;

            foreach (var player in m_players)
            {
                if (player.transform.position.y > highestPlayer)
                    highestPlayer = player.transform.position.y;
            }

            if (highestPlayer - m_catchupDistance > powerup.transform.position.y)
                powerup.gameObject.SetActive(true);
            else
                powerup.gameObject.SetActive(false);
        }
    }

}
