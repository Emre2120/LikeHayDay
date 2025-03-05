using System.Collections;
using UnityEngine;

public abstract class Seed : MonoBehaviour
{
 public int growUpTime;
    public GameObject[] growUpLevels;
    public Transform spawnPoint;
    [SerializeField] int growUpLevel;
    private float slicedWaitTime;
    private GameObject currentPlantInstance;
    public bool ripeCrop;
    public ObjectInfo objectInfo;

    private void Start()
    {
        if (growUpLevels == null || growUpLevels.Length == 0)
        {
            return;
        }

        slicedWaitTime = growUpTime / growUpLevels.Length +1;
        objectInfo.remainingTime = growUpTime;
        GrowToNextLevel();
        StartCoroutine(Grow());
        StartCoroutine(CalcuateRemainingTime());
    }

    IEnumerator Grow()
    {
        while (growUpLevel < growUpLevels.Length)
        {
            yield return new WaitForSeconds(slicedWaitTime);

            GrowToNextLevel();
        }
    }
    
    IEnumerator CalcuateRemainingTime()
    {
        while (objectInfo.remainingTime>0)
        {
            yield return new WaitForSeconds(1);
            objectInfo.remainingTime -= 1;
        }
        ripeCrop = true;
    }

    private void GrowToNextLevel()
    {
        if (currentPlantInstance != null)
        {
            Destroy(currentPlantInstance);
        }

        if (growUpLevel < growUpLevels.Length && growUpLevels[growUpLevel] != null)
        {
            currentPlantInstance = Instantiate(growUpLevels[growUpLevel], spawnPoint.position, Quaternion.identity, spawnPoint);
        }

        growUpLevel++;
    }
    public virtual void Collect()
    {
      
    }
}
