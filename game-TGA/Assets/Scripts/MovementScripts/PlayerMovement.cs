using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{

    #region vars

    private Vector3 _currentPosition;

    [SerializeField] private Joystick _joystick;
    Rigidbody2D rigidbody2D;

    private bool _leftDown;
    private bool _rightDown;

    [SerializeField] private float _movementSpeed = 200f;
    [SerializeField] private float _jumpForce = 500f;
    [SerializeField] private float _downForce = 200f;
    private float _horizontalInput;

    [SerializeField] private float _maxRotation = 45;

    #endregion

    public void LoadData(GameData data) {
        _currentPosition.x = data.playerPosition[0];
        _currentPosition.y = data.playerPosition[1];
        _currentPosition.z = data.playerPosition[2];
        rigidbody2D.position = _currentPosition;
    }

    public void SaveData(GameData data) {
        data.playerPosition[0] = this._currentPosition.x;
        data.playerPosition[1] = this._currentPosition.y;
        data.playerPosition[2] = this._currentPosition.z;
        data.stage = FindObjectOfType<StageManager>().getStage();
    }

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Jump();
        ShiftDown();
        MovePlayer();
        RotationController();
    }

    private void MovePlayer() {
        if ((!IsTouchingLeftWall.isTouchingLeftWall && !IsTouchingRightWall.isTouchingRightWall) || (IsTouchingLeftWall.isTouchingLeftWall && _horizontalInput >= 0) || (IsTouchingRightWall.isTouchingRightWall && _horizontalInput <= 0)) {
            transform.Translate(new Vector3(_horizontalInput, 0, 0) * _movementSpeed * Time.deltaTime);
        }
        _horizontalInput = _joystick.Horizontal;
        _currentPosition = rigidbody2D.position;
    }

    private void Jump() {
        if (IsGrounded.isGrounded && (_joystick.Vertical > 0.3f  || JumpPressed.jumpPressed) && Math.Abs(rigidbody2D.velocity.y) < 0.5f) {
            rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void ShiftDown() {
        if(!IsGrounded.downShiftUsed && !IsGrounded.isGrounded && (_joystick.Vertical < -0.3f /*|| ShiftDownButtonPressed*/)) {
            rigidbody2D.AddForce(new Vector2(0f, -_downForce), ForceMode2D.Impulse);
            IsGrounded.downShiftUsed = true;
        }
    }

    public void InputLeft() {
        _horizontalInput = -1;
    }

    public void InputRight() {
        _horizontalInput = 1;
    }

    
    private void RotationController() {
        if (rigidbody2D.rotation < -_maxRotation) {
            rigidbody2D.rotation = -_maxRotation;
        } else if (rigidbody2D.rotation > _maxRotation) {
            rigidbody2D.rotation = _maxRotation;
        }
    }
    
    public void SetPlayerPosition(int[] pos) {
        transform.Translate(new Vector3(pos[0] - transform.position.x, pos[1] - transform.position.y, 0));
    }
}
