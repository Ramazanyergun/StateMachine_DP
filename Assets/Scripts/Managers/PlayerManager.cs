using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager m_inputManager;
    private PlayerMovement m_playerMovement;
    private CameraManager m_cameraManager;
    void Awake()
    {
        m_inputManager = GetComponent<InputManager>();

        m_playerMovement = GetComponent<PlayerMovement>();
        m_cameraManager = FindAnyObjectByType<CameraManager>();

    }

    void Update()
    {
        m_inputManager.HandleAllInputs();
    }
    void FixedUpdate()
    {
        if (m_playerMovement != null)
            m_playerMovement.HandleAllMovements();
    }
    void LateUpdate()
    {
        if (m_cameraManager != null)
            m_cameraManager.HandleAllCameraMovement();
    }
}
