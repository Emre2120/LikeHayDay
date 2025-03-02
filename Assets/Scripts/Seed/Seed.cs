using System.Collections;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public int growUpTime;
    public GameObject[] growUpLevels;
    public Transform spawnPoint;

    [SerializeField] int growUpLevel;
    private float slicedWaitTime;
    private GameObject currentPlantInstance;
    public int remainingTime;

    private void Start()
    {
        if (growUpLevels == null || growUpLevels.Length == 0)
        {
            Debug.Log("Büyüme aşamaları dizisi boş veya atanmamış");
            return;
        }

        slicedWaitTime = growUpTime / growUpLevels.Length +1;
        remainingTime = growUpTime;
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
        while (growUpLevel < growUpLevels.Length)
        {
            yield return new WaitForSeconds(1);
            remainingTime -= 1;
        }
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

}