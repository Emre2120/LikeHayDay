using UnityEngine;

public class EditModeHandler : MonoBehaviour
{
public enum EditMode
{
farming,
editing,
reaping,
}
public static EditModeHandler instance;
public EditMode editMode;
public GameObject seed;
public GameObject cornSeed;
public GameObject wheatSeed;
public GameObject ChoseSeedPanel;
public TargetMarker targetMarker;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
 
   public void FarmingMode()
   {
      editMode = EditMode.farming;
      ChoseSeedPanel.SetActive(true);
      targetMarker.markerID = "infield";
      targetMarker.targetMarker.transform.localScale = new Vector3(2, 2,2);
      ObjectInfoWriter.instance.WriteObjectInfo("EKIM MODU");
   }

      public void EditingMode()
   {
      editMode = EditMode.editing;
      ChoseSeedPanel.SetActive(false);
      ObjectInfoWriter.instance.WriteObjectInfo("KONUMLANDIRMA MODU");
   }
      public void ReapingMode()
   {
      editMode = EditMode.reaping;
      ChoseSeedPanel.SetActive(false);
     // targetMarker.markerID = "infield";
     ObjectInfoWriter.instance.WriteObjectInfo("HASAT MODU");
   }

      public void SelectCornSeed()
   {
      seed = cornSeed;
      targetMarker.markerID = "infield";
      targetMarker.targetMarker.transform.localScale = new Vector3(2, 2,2);
      ObjectInfoWriter.instance.WriteObjectInfo("EKIM MODU (MISIR)");
   }
      public void SelectWheatSeed()
   {
      seed = wheatSeed;
      targetMarker.markerID = "infield";
      targetMarker.targetMarker.transform.localScale = new Vector3(2, 2,2);
      ObjectInfoWriter.instance.WriteObjectInfo("EKIM MODU (BUĞDAY)");
   }
}
