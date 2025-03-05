using UnityEngine;

public class GridHandler : MonoBehaviour
{
public Grid grid;
public GridInput gridInput;
public bool seeding = false;
public TargetMarker marker;
private GameObject targetMarker;
public EditModeHandler editModeHandler;
private void Start()
{
    targetMarker = marker.targetMarker;
}

private void LateUpdate()
{
    HandleEditMode();
    if(EditModeHandler.instance.editMode == EditModeHandler.EditMode.farming ||EditModeHandler.instance.editMode == EditModeHandler.EditMode.editing  ){HandleMarkerPlace();}
}

void HandleEditMode()
{
  if (gridInput.GetPlacementInput()&& EditModeHandler.instance.editMode  == EditModeHandler.EditMode.farming && marker.puttable == true && gridInput.touchedCount > 1  && marker.touching == false && marker.seedable == true)
 {   
      Instantiate(editModeHandler.seed, targetMarker.transform.position, Quaternion.identity);
 }
 else if (EditModeHandler.instance.editMode  == EditModeHandler.EditMode.editing && gridInput.GetPlacementInput() && marker.puttable == true && gridInput.touchedCount > 1 && marker.touching == false)
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