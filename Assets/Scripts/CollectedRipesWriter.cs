using TMPro;
using UnityEngine;

public class CollectedRipesWriter : MonoBehaviour
{
    public int CornCount = 0;
    public int wheatCount = 0;
    public TextMeshProUGUI cornText;
    public TextMeshProUGUI wheatText;
    public GameFinisher gameFinisher;
    public int collectedCount;
    void Start()
    {
        cornText.text = CornCount.ToString();
        wheatText.text = wheatCount.ToString();
    }
    private void OnEnable()
    {
        EventManager.OnCollectCornRipe += AddCornCount;
        EventManager.OnCollectWheatRipe += AddWheatCount;
    }

    private void OnDisable()
    {
        EventManager.OnCollectCornRipe -= AddCornCount;
        EventManager.OnCollectWheatRipe -= AddWheatCount;
    }

    private void AddCornCount(int amount)
    {
        CornCount += amount;
        Debug.Log("Corn count: " + CornCount);
        cornText.text = CornCount.ToString();
        ControlFinish();
    }
    
    private void AddWheatCount(int amount)
    {
        wheatCount += amount;
        Debug.Log("wheat count " + wheatCount);
        wheatText.text = wheatCount.ToString();
        ControlFinish();
    }

    void ControlFinish()
    {
        collectedCount++;
        if(collectedCount>= 20)
        {
           gameFinisher.gameFinishPanel.SetActive(true);
        }
    }
}
