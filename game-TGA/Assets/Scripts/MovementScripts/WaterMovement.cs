using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour, IDataPersistence
{
    #region vars
    private Vector3 _currentPosition;
    [SerializeField] private float movementSpeed;
    private float _horizontalInput;
    private float _verticalInput;
    [SerializeField] private Joystick joystick;

    #endregion

    public void LoadData(GameData data) {
        _currentPosition.x = data.playerPosition[0];
        _currentPosition.y = data.playerPosition[1];
        _currentPosition.z = data.playerPosition[2];
        transform.position.Set(_currentPosition.x, _currentPosition.y, _currentPosition.z);
    }

    public void SaveData(GameData data) {
        data.playerPosition[0] = this._currentPosition.x;
        data.playerPosition[1] = this._currentPosition.y;
        data.playerPosition[2] = this._currentPosition.z;
        data.stage = FindObjectOfType<StageManager>().getStage();
    }

    private void FixedUpdate() {
        //checking for walls and moving horizontally
        if((!IsTouchingLeftWall.isTouchingLeftWall && !IsTouchingRightWall.isTouchingRightWall) || (IsTouchingLeftWall.isTouchingLeftWall && _verticalInput >= 0) || (IsTouchingRightWall.isTouchingRightWall && _verticalInput <= 0)) {
            transform.Translate(new Vector3(_horizontalInput, 0, 0) * movementSpeed * Time.deltaTime);
        }

        //checking for ground/ceiling and moving vertically
        if((!IsGrounded.isGrounded && !IsTouchingCeiling.isTouchingCeiling) || (IsGrounded.isGrounded && _horizontalInput >= 0) || (IsTouchingCeiling.isTouchingCeiling && _horizontalInput <= 0)) {
            transform.Translate(new Vector3(0, _verticalInput, 0) * movementSpeed * Time.deltaTime);
        }
        _horizontalInput = joystick.Horizontal;
        _verticalInput = joystick.Vertical;
        _currentPosition = transform.position;
    }

}
