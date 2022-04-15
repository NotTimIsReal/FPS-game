using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    public PlayerInput.UIActions ui;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerWeapon weapon;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();

        ui = playerInput.UI;
        weapon = GetComponent<PlayerWeapon>();


        onFoot.Jump.performed += ctx => motor.Jump();
        look = GetComponent<PlayerLook>();

        ui.UnlockMouse.performed += ctx => { Cursor.lockState = CursorLockMode.None; Debug.Log("Unlock"); };

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

    }
    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
