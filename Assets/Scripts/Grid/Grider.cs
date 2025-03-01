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

private void Update()
{

    SelectEditMode();
    HandleMarkerPlace();
}

void SelectEditMode()
{
  if (gridInput.GetPlacementInput() && marker.puttable == true && gridInput.touchCount > 1 && seeding == true && marker.touching == false)
 {
      Instantiate(seedPlant, targetMarker.transform.position, Quaternion.identity);
 }
 else if (seeding == false && gridInput.GetPlacementInput() && marker.puttable == true && gridInput.touchCount > 1 && marker.touching == false)
 {
        gridInput.lastTouchedGameObject.transform.position = targetMarker.transform.position;
 }
}

void HandleMarkerPlace()
{
    Vector3 selectedPosition = gridInput.GetSelectedMapPosition();
    Vector3Int cellPosition = grid.WorldToCell(selectedPosition);
    targetMarker.transform.position = grid.GetCellCenterWorld(cellPosition);
}

}