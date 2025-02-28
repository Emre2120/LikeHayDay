using UnityEngine;

public class Grider : MonoBehaviour
{
public GameObject targetMarker, seedPlant;
public Grid grid;
public GridInput gridInput;

private void Update()
{
Vector3 selectedPosition = gridInput.GetSelectedMapPosition();
Vector3Int cellPosition = grid.WorldToCell(selectedPosition);
targetMarker.transform.position = grid.GetCellCenterWorld (cellPosition);

if (gridInput.GetPlacementInput() && gridInput.touchCount > 1 && targetMarker.GetComponent<TargetMarker>().touching == false)
Instantiate (seedPlant, targetMarker.transform.position,Quaternion.identity);
}
}
