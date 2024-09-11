using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private Vector2 movementInput;
    private PlayerMovement movement;
    private GunScript weapon;
    private PlayerCamera cam;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = new PlayerInput();
        movement = GetComponent<PlayerMovement>();
        cam = GetComponent<PlayerCamera>();
        onFoot = playerInput.OnFoot;
        onFoot.Jump.performed += ctx => movement.Jump();
        //onFoot.Sprint.started += ctx => movement.Sprint();
        onFoot.Sprint.canceled += ctx => movement.Walk();
        //onFoot.Reload.performed += ctx => weapon.Reload();
        //onFoot.WeaponFire.performed += ctx => weapon.Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        movement.ProcessMovement(onFoot.Movement.ReadValue<Vector2>());
        cam.ProcessCamera(onFoot.Look.ReadValue<Vector2>());
    }

    //private void LateUpdate()
    //{
    //    cam.ProcessCamera(onFoot.Look.ReadValue<Vector2>());
    //}

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
