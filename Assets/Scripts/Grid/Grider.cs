using UnityEngine;

public class Grider : MonoBehaviour
{
public GameObject seedPlant;
public Grid grid;
public GridInput gridInput;
public bool seeding = false;
public TargetMarker marker;
private GameObject targetMarker;

private void Start()
{
    targetMarker = marker.targetMarker;
}

private void LateUpdate()
{
    SelectEditMode();
    HandleMarkerPlace();
}

void SelectEditMode()
{
  if (gridInput.GetPlacementInput() && marker.puttable == true && gridInput.touchedCount > 1 && seeding == true && marker.touching == false && marker.seedable == true)
 {   
      Instantiate(seedPlant, targetMarker.transform.position, Quaternion.identity);
 }
 else if (seeding == false && gridInput.GetPlacementInput() && marker.puttable == true && gridInput.touchedCount > 1 && marker.touching == false)
 {     
    if(gridInput.lastTouchedGameObject!= null){ gridInput.lastTouchedGameObject.transform.position = targetMarker.transform.position;}
 }
}

void HandleMarkerPlace()
{
    Vector3 selectedPosition = gridInput.GetSelectedMapPosition();
    Vector3Int cellPosition = grid.WorldToCell(selectedPosition);
    targetMarker.transform.position = grid.GetCellCenterWorld(cellPosition);
}

}