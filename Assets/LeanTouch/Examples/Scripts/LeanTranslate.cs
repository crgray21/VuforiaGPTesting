using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to transform the current GameObject
	public class LeanTranslate : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("The camera the translation will be calculated using (None = MainCamera)")]
		public Camera Camera;

#if UNITY_EDITOR
        protected virtual void Reset()
		{
			Start();
		}
#endif

		protected virtual void Start()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}

        protected virtual void Update()
        {
            // If we require a selectable and it isn't selected, cancel translation
            if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
            {
                return;
            }

            // Get the fingers we want to use
            var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount, RequiredSelectable);

            // Calculate the screenDelta value based on these fingers
            var screenDelta = LeanGesture.GetScreenDelta(fingers);
            int layerMask = ~LayerMask.GetMask("Ignore Raycast");

            if (Input.GetMouseButton(0))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit, Mathf.Infinity, layerMask, QueryTriggerInteraction.UseGlobal))
                {
                    // Perform the translation
                    Debug.Log("Ray hit occurred!");
                    Translate(screenDelta, raycastHit);
                }
            }
        }

		protected virtual void Translate(Vector2 screenDelta, RaycastHit hit)
		{
			// Make sure the camera exists
			var camera = LeanTouch.GetCamera(Camera, gameObject);

			if (camera != null)
			{
                Debug.Log("Calculating new position...");
                Debug.Log(hit.transform.gameObject.name);
				// Screen position of the transform
				var screenPosition = camera.WorldToScreenPoint(hit.transform.position);

				// Add the deltaPosition
				screenPosition += (Vector3)screenDelta;

				// Convert back to world space
			    hit.transform.position = camera.ScreenToWorldPoint(screenPosition);
			}
		}
	}
}