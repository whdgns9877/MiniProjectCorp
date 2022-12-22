using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject PauseMenuUI;
    
    public void SceneChange()
    {
        SceneManager.LoadScene("CMJScene");
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Yes();
            }

            else
            {
                No();
            }
        }
    }

    public void Yes()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    public void No()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

}


