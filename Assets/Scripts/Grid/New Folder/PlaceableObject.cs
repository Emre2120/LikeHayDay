using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
public bool Placed { get; private set; }
private Vector3 origin;
public BoundsInt area;
public bool CanBePlaced ()
{
Vector3Int positionInt = BuildingSystem.current.gridLayout.LocalToCell (transform.position);
BoundsInt areaTemp = area;
areaTemp.position = positionInt;

if (BuildingSystem.current.CanTakeArea (areaTemp))
{
return true;
}
return false;
}

public void Place()
{
Vector3Int positionInt = BuildingSystem.current.gridLayout.LocalToCell (transform.position);
BoundsInt areaTemp = area;
areaTemp.position = positionInt;
Placed = true;
BuildingSystem.current.TakeArea (areaTemp);
}
public void CheckPlacement ()
{
if (CanBePlaced())
{
Place();
origin = transform.position;
}
else
{
Destroy(transform.gameObject);
}

//ShopManager.current.ShopButton_Click();|
}
}
