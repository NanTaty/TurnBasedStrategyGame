using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private InputSystem inputSystem;
    
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There's more than one InputManager!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inputSystem = new InputSystem();
        inputSystem.Player.Enable();
    }

    public Vector2 GetCameraMoveAmount()
    {
        return inputSystem.Player.CameraMovement.ReadValue<Vector2>();
    }

    public float GetCameraRotateAmount()
    {
        return inputSystem.Player.CameraRotation.ReadValue<float>();
    }

    public float GetCameraZoomAmount()
    {
        return inputSystem.Player.CameraZoom.ReadValue<float>();
    }

    public Vector2 GetMouseScreenPosition()
    {
        return Mouse.current.position.ReadValue();
    }
}
