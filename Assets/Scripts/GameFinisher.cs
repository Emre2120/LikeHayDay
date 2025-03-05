using UnityEngine;

public class GameFinisher : MonoBehaviour
{
public GameObject gameFinishPanel;

public void No()
{
  gameFinishPanel.SetActive(false);
}
public void QuitGame()
{
  Application.Quit(); 
}
}
