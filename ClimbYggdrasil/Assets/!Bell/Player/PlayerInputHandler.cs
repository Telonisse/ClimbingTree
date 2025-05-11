using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput input;
    private PlayerMovement playerMovement;

    [SerializeField] PlayerInputManager playerInputManager;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    
    int playerIndex = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();

        Gamepad[] gamepads = Gamepad.all.ToArray();
        InputDevice device = gamepads[playerIndex];
        playerInputManager.playerPrefab = player1;
        PlayerInput playerInput = playerInputManager.JoinPlayer(playerIndex, playerIndex, "Player", device);
        FindAnyObjectByType<DistanceCounter>().SetP1(playerInput.gameObject);
        playerIndex++;
        playerInputManager.playerPrefab = player2;
        InputDevice device1 = gamepads[playerIndex];
        PlayerInput playerInput1 = playerInputManager.JoinPlayer(playerIndex, playerIndex, "Player", device1);
        FindAnyObjectByType<DistanceCounter>().SetP2(playerInput.gameObject);
        //var index = input.playerIndex;
        //var players = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
        //playerMovement = players.FirstOrDefault(m => m.GetPlayerIndex() == index);
        //input.camera = playerMovement.GetComponentInChildren<Camera>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (playerMovement != null)
        {
            //playerMovement.SetInputVector(context.ReadValue<Vector2>());
        }
    }
}
