using UnityEngine;

public class GridInput : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 lastPosition;
    public LayerMask groundLayerMask;
    public int touchCount;
    public GameObject lastTouchedGameObject;
    public TargetMarker targetMarker;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 touchPos = Vector3.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = touch.position;

            Ray ray = sceneCamera.ScreenPointToRay(touchPos);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
            {
                lastPosition = hit.point;
                GameObject interactedObject = hit.collider.gameObject;

                // Eğer etkileşimli obje ile ilk defa karşılaşıyorsak
                if (interactedObject.CompareTag("Interactable") && interactedObject != lastTouchedGameObject)
                {
                    lastTouchedGameObject = interactedObject;
                    Collider touchedObjectCollider = lastTouchedGameObject.GetComponent<Collider>();
                    Collider targetCollider = targetMarker.targetMarker.GetComponent<Collider>();
                    targetCollider.transform.localScale = touchedObjectCollider.transform.localScale;
                    
                    MeshFilter touchedObjectFilter = lastTouchedGameObject.GetComponent<MeshFilter>();
                    MeshFilter targetFilter = targetMarker.targetMarker.GetComponent<MeshFilter>();
                    targetFilter.mesh = touchedObjectFilter.mesh;
                }
            }
        }

        return lastPosition;
    }

    public bool GetPlacementInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchCount += 1;
                return true;
            }
        }
        return false;
    }
}
