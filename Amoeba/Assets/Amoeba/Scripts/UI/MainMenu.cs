using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(string sceneName)
        {
          Application.LoadLevel(sceneName);
        }

    public void QuitApplication()
      {
        Application.Quit();
      }
}
