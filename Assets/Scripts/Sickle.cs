using System;
using UnityEngine;

public class Sickle : MonoBehaviour
{
public GridInput gridInput;
public MeshRenderer meshRenderer;

    void Update()
    {
        if(EditModeHandler.instance.editMode  ==  EditModeHandler.EditMode.reaping)
        {
         transform.position = gridInput.GetSelectedMapPosition();
          meshRenderer.enabled = true;
        }else
        {
          meshRenderer.enabled = false;
        } 
    }

    void OnTriggerEnter(Collider other)
    {
   if (other.gameObject.TryGetComponent<Seed>(out Seed seed) && seed.ripeCrop)
   {
      seed.Collect();
      Destroy(other.gameObject);
   }     
    }
}
