using UnityEngine;

public class GridInput : MonoBehaviour
{
    public Camera sceneCamera;
    public LayerMask groundLayerMask;
    public LayerMask interactableLayerMask;
    public TargetMarker targetMarker;

    private Vector3 lastPosition;
    public GameObject lastTouchedGameObject;
    public int touchedCount;

    public Vector3 GetSelectedMapPosition()
    {
       if (sceneCamera == null){ return Vector3.zero;}
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = sceneCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
            {
                lastPosition = hit.point;
            }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayerMask))
            {
                if (hit.collider.gameObject != lastTouchedGameObject)
                {
                    lastTouchedGameObject = hit.collider.gameObject;
                    PlaceInfo touchedInfo = lastTouchedGameObject.GetComponent<PlaceInfo>();
                    targetMarker.targetMarker.transform.localScale = new Vector3(touchedInfo.markerSizeX, touchedInfo.markerSizeY, touchedInfo.markerSizeZ);
                    targetMarker.markerID = touchedInfo.placeID;
                    if (lastTouchedGameObject.TryGetComponent<Seed>(out Seed seedInfo)) { ObjectInfoWriter.instance.WriteRemainingTime(seedInfo.remainingTime); }
                    HandleTouchedObject();
                }
            }
        }

        return lastPosition;
    }

    void HandleTouchedObject()
    {

    }

    public bool GetPlacementInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchedCount++;
                return true;
            }
        }
        return false;
    }
}