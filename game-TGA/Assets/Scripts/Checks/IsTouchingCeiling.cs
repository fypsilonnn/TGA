using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingCeiling : MonoBehaviour
{
    public static bool isTouchingCeiling;

    private void OnTriggerEnter2D() {
        isTouchingCeiling = true;
    }

    private void OnTriggerExit2D() {
        isTouchingCeiling = false;
    }
}
