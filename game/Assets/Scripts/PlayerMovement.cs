using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _currentVelocity;

    public Joystick joystick;
    Rigidbody2D rigidbody2D;

    private bool _leftDown;
    private bool _rightDown;

    public float movementSpeed = 100f;
    public float jumpForce = 100f;
    public float downForce = 50f;
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
        ShiftDown();
        MovePlayer(); 
    }

    private void MovePlayer() {

        transform.Translate(new Vector3(_horizontalInput, 0, 0) * movementSpeed * Time.deltaTime);
        _horizontalInput = joystick.Horizontal;
    }

    public void Jump() {
        if (IsGrounded.isGrounded && (joystick.Vertical > 0.3f  || JumpPressed.jumpPressed)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void ShiftDown() {
        //TODO: momentum stacking verhindern
        if(!IsGrounded.isGrounded && (joystick.Vertical < -0.3f /*|| ShiftDownButtonPressed*/)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -downForce), ForceMode2D.Impulse);
        }
    }

    public void InputLeft() {
        _horizontalInput = -1;
    }

    public void InputRight() {
        _horizontalInput = 1;
    }

    

}
