using System;
using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    public bool touching = false;
    public PlaceInfo placeInfo;
    public string markerID;
    public bool puttable = false;
    public GameObject targetMarker;
    public bool seedable;
    
    void Update()
    {
        CheckObjectBelow();
    }

    void OnTriggerEnter(Collider other)
    {
        touching = true;
    }

    void OnTriggerExit(Collider other)
    {
        touching = false;
    }

    void CheckObjectBelow()
    {
        Vector3 rayStart = transform.position;
        Vector3 rayDirection = Vector3.down;
        float rayDistance = 10f;
        Debug.DrawRay(rayStart, rayDirection * rayDistance, Color.red);
        if (Physics.Raycast(rayStart, rayDirection, out RaycastHit hit, rayDistance))
        {
            PlaceInfo hitPlaceInfo = hit.collider.GetComponent<PlaceInfo>();

            if (hitPlaceInfo != null)
            {
                string hitObjectID = hitPlaceInfo.placeID;
                seedable = hitPlaceInfo.seedable;
                if (hitObjectID == markerID)
                {
                    puttable = true;
                }
                else
                {
                    puttable = false;
                }
            }
        }
        else
        {
            puttable = false;
        }
    }
}