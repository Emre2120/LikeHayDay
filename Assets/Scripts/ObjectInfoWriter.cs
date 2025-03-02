using UnityEngine;
using TMPro;
using System.Collections;
public class ObjectInfoWriter : MonoBehaviour
{
  public static ObjectInfoWriter instance;
  public TextMeshProUGUI remainingTimeText;
  public int waitTime;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
 
        public void WriteRemainingTime(int remainingTime)
    {
        waitTime = remainingTime;
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (waitTime > 0)
        {
            yield return new WaitForSeconds(1);
            waitTime--;
            WriteRemainingTime(waitTime);
        }
    }
  
}
