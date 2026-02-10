using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager; 
    private PlayerMovement playerMovement;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();

        try
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
   
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
