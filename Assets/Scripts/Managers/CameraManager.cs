using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{

    public Transform targetTransform;
    public Transform cameraPivot;
    public Transform cameraTransform;
    public LayerMask collisionLayers;
    private float _defaultPosition;
    private Vector3 _cameraFollowVelocity = Vector3.zero;
    private Vector3 _cameraVectorPosition;

    public float followSpeed = 0.2f;
    public float minimumCollisionOffset = 0.2f;
    public float lookAngle;
    public float pivotAngle;
    public float minimumPivotAngle = -35f;
    public float maximumPivotAngle = 35f;
    public float cameraCollisionRadius = 2f;
    private float _cameraLookSpeed = 0.25f;
    private float _cameraPivotSpeed = 0.25f;
    public float cameraCollisionOffset = 0.2f;

    private void Awake()
    {
        _defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowPlayer();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowPlayer()
    {
        Vector3 targerPosition = Vector3.SmoothDamp(transform.position, targetTransform.position,
            ref _cameraFollowVelocity, followSpeed);

        transform.position = targerPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle += InputManager.Instance.cameraInputX * _cameraLookSpeed;
        pivotAngle -= InputManager.Instance.cameraInputY * _cameraPivotSpeed;
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);

        transform.rotation = targetRotation;
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = _defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit,
                Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition -= distance - cameraCollisionOffset;
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
        {
            targetPosition -= minimumCollisionOffset;
        }

        _cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = _cameraVectorPosition;
    }
}