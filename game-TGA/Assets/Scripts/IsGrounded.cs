using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public static bool isGrounded;
    public static bool downShiftUsed;

    private void OnTriggerEnter2D(Collider2D collision) {
        isGrounded = true;
        downShiftUsed = false;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isGrounded = false;
    }
}
