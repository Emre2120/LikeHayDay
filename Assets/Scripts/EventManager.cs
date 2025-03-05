using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> OnCollectCornRipe;
    
     public static event Action<int> OnCollectWheatRipe;
     
    public static void CollectCornRipe(int amount)
    {
        OnCollectCornRipe?.Invoke(amount);
    }
    
    public static void CollectWheatRipe(int amount)
    {
        OnCollectWheatRipe?.Invoke(amount);
    }
}
