using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform cameraLookTarget;
    [SerializeField] InputController inputController;
    [SerializeField] PlayerSettings playerSettings;

    private readonly float maxVert = 10f;
    private readonly float minVert = -20f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private readonly Vector3 cameraOffset = new Vector3(0, 0.25f, -2);

    public float _rotationX;
    public float _rotationY;

    private Vector2 mouseInput;
    
    void Update()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, inputController.MouseInput.x, 1f / playerSettings.MouseDamping);
        mouseInput.y = Mathf.Lerp(mouseInput.y, inputController.MouseInput.y, 1f / playerSettings.MouseDamping);

        targetPosition = cameraLookTarget.position + player.transform.forward * cameraOffset.z +
                player.transform.up * cameraOffset.y +
                player.transform.right * cameraOffset.x;

        targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, playerSettings.CameraInterpolation * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, playerSettings.CameraInterpolation * Time.deltaTime);

        _rotationX -= mouseInput.y * playerSettings.MouseSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

        player.transform.Rotate(Vector3.up * mouseInput.x * playerSettings.MouseSensitivity);

        Vector3 rotation = transform.localEulerAngles;
        rotation.x = _rotationX;

        transform.localEulerAngles = rotation;

    }
}
