using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();

        playerMovement = GetComponent<PlayerMovement>();


    }

    void Update()
    {
        inputManager.HandleAllInputs();
    }
    void FixedUpdate()
    {
        if (playerMovement != null)
            playerMovement.HandleAllMovements();
    }

}
