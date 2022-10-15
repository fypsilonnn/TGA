using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }

    public Joystick joystick;
    Rigidbody2D rigidbody2D;

    private bool _leftDown;
    private bool _rightDown;

    public float _movementSpeed = 10f;
    private float _horizontalInput;
    private float _verticalInput;

    private float _fallspeed;
    private float _minFallspeed;
    private float _maxFallspeed;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Jump();
        MovePlayer(); 
    }

    private void MovePlayer() {

        transform.Translate(new Vector3(_horizontalInput, 0, 0) * _movementSpeed * Time.deltaTime);
        _horizontalInput = joystick.Horizontal;
    }

    public void Jump() {
        if (/*IsGrounded && */(joystick.Vertical > 0.3f /* || Jump pressed */)) { 

        }
    }

    public void InputLeft() {
        _horizontalInput = -1;
    }

    public void InputRight() {
        _horizontalInput = 1;
    }

    

}
