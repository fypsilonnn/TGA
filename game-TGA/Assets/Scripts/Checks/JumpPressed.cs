using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpPressed : MonoBehaviour
{
    public static bool jumpPressed;

    private void Start() {
        EventTrigger triggerDown = GetComponent<EventTrigger>();
        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        triggerDown.triggers.Add(entryDown);

        EventTrigger triggerUp = GetComponent<EventTrigger>();
        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData) data); });
        triggerUp.triggers.Add(entryUp);
    }

    private void OnPointerDownDelegate(PointerEventData data) {
       jumpPressed = true;
    }

    private void OnPointerUpDelegate(PointerEventData data) {
        jumpPressed = false;
    }
}
