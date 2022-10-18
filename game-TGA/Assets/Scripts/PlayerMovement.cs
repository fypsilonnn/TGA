using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _currentVelocity;

    public Joystick joystick;
    Rigidbody2D rigidbody2D;

    public Animator animator;

    private bool _leftDown;
    private bool _rightDown;

    public float movementSpeed = 100f;
    public float jumpForce = 100f;
    public float downForce = 200f;
    private float _horizontalInput;
    private float _horizontalSpeed;
    private float _verticalInput;

    public float maxRotation = 30;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        AnimationHandler();
        Jump();
        ShiftDown();
        MovePlayer();
        RotationController();
    }

    private void MovePlayer() {
        if ((!IsTouchingLeftWall.isTouchingLeftWall && !IsTouchingRightWall.isTouchingRightWall) || (IsTouchingLeftWall.isTouchingLeftWall && _horizontalInput >= 0) || (IsTouchingRightWall.isTouchingRightWall && _horizontalInput <= 0)) {
            transform.Translate(new Vector3(_horizontalInput, 0, 0) * movementSpeed * Time.deltaTime);
        }
        _horizontalInput = joystick.Horizontal;
        _horizontalSpeed = _horizontalInput * movementSpeed;
    }

    private void Jump() {
        if (IsGrounded.isGrounded && (joystick.Vertical > 0.3f  || JumpPressed.jumpPressed) && rigidbody2D.velocity.y == 0f) {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    private void ShiftDown() {
        if(!IsGrounded.downShiftUsed && !IsGrounded.isGrounded && (joystick.Vertical < -0.3f /*|| ShiftDownButtonPressed*/)) {
            rigidbody2D.AddForce(new Vector2(0f, -downForce), ForceMode2D.Impulse);
            IsGrounded.downShiftUsed = true;
        }
    }

    public void InputLeft() {
        _horizontalInput = -1;
    }

    public void InputRight() {
        _horizontalInput = 1;
    }

    private void AnimationHandler() {
        animator.SetFloat("Speed", Math.Abs(_horizontalSpeed));
        if(IsGrounded.isGrounded) {
            animator.SetBool("IsJumping", false);
        }
    }

    private void RotationController() {
        if (rigidbody2D.rotation < -maxRotation) {
            rigidbody2D.rotation = -maxRotation;
        } else if (rigidbody2D.rotation > maxRotation) {
            rigidbody2D.rotation = maxRotation;
        }
    }
}
