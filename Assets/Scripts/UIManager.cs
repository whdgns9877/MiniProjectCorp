using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager GameMgr;
    
    public GameObject PauseCanvas;

    
    public void SceneChange()
    {
        SceneManager.LoadScene("CMJScene");
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.IsPause)
            {
                OnClickPause();
            }
            else
            {
                PauseCanvas.SetActive(false);
            }
        }


    }
    public void OnClickPause()
    {
        PauseCanvas.SetActive(true);
    }
}


