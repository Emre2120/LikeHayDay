using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetMarker : MonoBehaviour
{
  public bool touching = false;
  
    void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("UnAddable"))
         {
           touching = true;
         }
    }

        void OnTriggerExit(Collider other)
    {
         if(other.CompareTag("UnAddable"))
         {
           touching = false;
         }
    }
}
