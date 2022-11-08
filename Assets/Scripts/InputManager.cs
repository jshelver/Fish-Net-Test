using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    public static PlayerControls playerControls;
    public static event Action<InputActionMap> actionMapChange;

    [Header("Game Input Variables")]
    public static Vector2 movementInput;
    public static Vector2 lookInput;
    public static bool jumpInput;
    public static bool gameEscapeInput;

    [Header("UI Input Variables")]
    public static bool gameIsPaused;
    public static bool menuEscapeInput;
    public static bool clickInput;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        movementInput = playerControls.Player.Movement.ReadValue<Vector2>();
        lookInput = playerControls.Player.Look.ReadValue<Vector2>();
        jumpInput = playerControls.Player.Jump.triggered;

        // Enter pause menu
        gameEscapeInput = playerControls.Player.Escape.triggered;
        if (gameEscapeInput)
        {
            gameIsPaused = true;
            SwitchActionMap(playerControls.UI);
        }

        // Exit pause menu
        menuEscapeInput = playerControls.UI.Escape.triggered;
        if (menuEscapeInput)
        {
            gameIsPaused = false;
            SwitchActionMap(playerControls.Player);
        }

        // Storing input in variables (ui action map)
        clickInput = playerControls.UI.Click.triggered;
    }

    public static void SwitchActionMap(InputActionMap actionMap)
    {
        // If the desired action map is already enabled then return
        // if (actionMap.enabled) return;

        // Disables every action map
        playerControls.Disable();
        // Call the action map change event so scripts are aware of the change (optional)
        actionMapChange?.Invoke(actionMap);
        // Enable desired action map
        actionMap.Enable();
        Debug.Log($"Current action map: {actionMap}");
    }

    void OnEnable()
    {
        playerControls.Player.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }
}
