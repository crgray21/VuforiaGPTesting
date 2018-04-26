using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject1 : MonoBehaviour, IDragHandler
{
    [Tooltip("Ignore fingers with StartedOverGui?")]
    public bool IgnoreGuiFingers = true;

    [Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
    public int RequiredFingerCount;

    [Tooltip("Does translation require an object to be selected?")]
    public Lean.Touch.LeanSelectable RequiredSelectable;

    [Tooltip("The camera the translation will be calculated using (None = MainCamera)")]
    public Camera Camera;

    public void OnDrag(PointerEventData eventData)
    {
        var camera = Lean.Touch.LeanTouch.GetCamera(Camera, gameObject);

        if (camera != null)
        {
            // Screen position of the transform
            var screenPosition = camera.WorldToScreenPoint(transform.position);
            var fingers = Lean.Touch.LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount, RequiredSelectable);
            var screenDelta = Lean.Touch.LeanGesture.GetScreenDelta(fingers);

            // Add the deltaPosition
            screenPosition += (Vector3)screenDelta;

            // Convert back to world space
            transform.position = camera.ScreenToWorldPoint(screenPosition);
        }
    }
}