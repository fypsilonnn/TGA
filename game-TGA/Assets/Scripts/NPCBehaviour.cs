using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCBehaviour : MonoBehaviour
{
    public bool wasSpokenTo = false;
    [SerializeField] UnityEvent onClick;

    private void OnMouseUp() {
        onClick.Invoke();
    }
}
