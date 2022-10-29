using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingLeftWall : MonoBehaviour
{
    public static bool isTouchingLeftWall;

    private void OnTriggerEnter2D(Collider2D collision) {
        isTouchingLeftWall = true;
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        isTouchingLeftWall = false;
    }
}
