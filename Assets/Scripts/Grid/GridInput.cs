using UnityEngine;

public class GridInput : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 m_lastPosition;
    public LayerMask groundLayerMask;
    public int touchCount;
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
                m_lastPosition = hit.point;
            }
            else
            {
                Debug.LogWarning("Raycast did not hit anything!");
            }
        }

        return m_lastPosition;
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