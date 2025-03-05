using System;
using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    public bool touching = false;
    public string markerID;
    public bool puttable = false;
    public GameObject targetMarker;
    public bool seedable;
    public Material blueMaterial;
    public Material redMaterial;
    private Renderer objRenderer;
    public MeshRenderer meshRenderer;
    
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }
    void Update()
    {
        CheckObjectBelow();
        HandlePlaceMaterial();
        HandleEditModeRequariments();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("ground")){touching = true;}
    }

    void OnTriggerExit(Collider other)
    {
        touching = false;
    }

    void HandlePlaceMaterial()
    {
       if(touching == true || puttable == false )
      {
         objRenderer.material = redMaterial;
      }
      if(touching == false && puttable == true )
      {
         objRenderer.material = blueMaterial;
      }
    }
    
    void HandleEditModeRequariments()
    {
        if(EditModeHandler.instance.editMode  == EditModeHandler.EditMode.farming ||EditModeHandler.instance.editMode  == EditModeHandler.EditMode.editing)
        {
          meshRenderer.enabled = true;
        }else
        {
          meshRenderer.enabled = false;
        }
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