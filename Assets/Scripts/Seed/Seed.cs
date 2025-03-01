using System.Collections;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public float growUpTime;
    public GameObject[] growUpLevels;
    public Transform spawnPoint;
    [SerializeField] int growUpLevel;
    private float slicedWaitTime;
    private GameObject currentPlantInstance;

    private void Start()
    {
        if (growUpLevels == null || growUpLevels.Length == 0)
        {
            Debug.Log("GrowUpLevels array is empty or not assigned!");
            return;
        }

        slicedWaitTime = growUpTime / growUpLevels.Length;
        GrowToNextLevel();
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        while (growUpLevel < growUpLevels.Length)
        {
            yield return new WaitForSeconds(slicedWaitTime); 
            GrowToNextLevel();
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