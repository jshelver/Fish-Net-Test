using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    PlayerControls playerControls;

    [Header("Input Variables")]
    public static Vector2 movementInput;
    public static Vector2 lookInput;
    public static bool jumpInput;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void Update()
    {
        movementInput = playerControls.Player.Movement.ReadValue<Vector2>();
        lookInput = playerControls.Player.Look.ReadValue<Vector2>();
        jumpInput = playerControls.Player.Jump.triggered;
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }
}
