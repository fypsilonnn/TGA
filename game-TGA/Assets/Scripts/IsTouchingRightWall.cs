using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingRightWall : MonoBehaviour
{
    public static bool isTouchingRightWall;

    private void OnTriggerEnter2D(Collider2D collision) {
        isTouchingRightWall = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isTouchingRightWall = false;
    }
}
