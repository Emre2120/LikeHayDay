using UnityEngine;
using TMPro;
using System.Collections;

public class ObjectInfoWriter : MonoBehaviour
{
    public static ObjectInfoWriter instance { get; private set; }
    public TextMeshProUGUI ObjectInfoText;
    public TextMeshProUGUI remainingTimeText;
    public int waitTime;
    private Coroutine countdownCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WriteObjectInfo(string objectInfo)
    {
       ObjectInfoText.text = objectInfo;
    }

    public void WriteRemainingTime(int remainingTime)
    {
        waitTime = remainingTime;
        Debug.Log(remainingTime);
        if (countdownCoroutine != null) 
        {
            StopCoroutine(countdownCoroutine); 
        }

        if (remainingTime <= 1)
        {
            remainingTimeText.text = "Done";
        }
        else
        {
            countdownCoroutine = StartCoroutine(CountdownTimer()); 
        }
    }

    IEnumerator CountdownTimer()
    {
        while (waitTime > 0)
        {
            remainingTimeText.text = "REMAINING TIME : " + waitTime.ToString();
            yield return new WaitForSeconds(1);
            waitTime--;
        }

        remainingTimeText.text = "Done";
        Debug.Log("ready !");
    }
}
 