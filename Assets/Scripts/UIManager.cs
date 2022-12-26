using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject PauseMenuUI;
    public GameObject _NUM_1;
    public GameObject _NUM_2;
    public GameObject _NUM_3;
    public GameObject _START;
    public TextMeshProUGUI timeText = null;

    private float minute = 0;
    private float second = 0;

    public void SceneChange()
    {
        //GameManager.Instance.AudioManager.PlaySound(AudioType.Button, false);
        SceneManager.LoadScene("KJHScene");
    }

    public void SceneReset()
    {
        SceneManager.LoadScene("GameStartScene");
    }
    private void Start()
    {
        _NUM_1.SetActive(false);
        _NUM_2.SetActive(false);
        _NUM_3.SetActive(false);
        _START.SetActive(false);
    }

    private void Update()
    {
        if (Time.timeScale != 0 && GameManager.Instance.IsGameStop == false)
        {
            second += Time.deltaTime;
            if (second >= 60)
            {
                minute++;
                second = 0;
            } 
        }
        timeText.text = string.Format("{0:D2}", (int)minute) + " : " + string.Format("{0:D2}", (int)second);

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
        Time.timeScale = 1f;
        StartCoroutine(PauseCountDown());
        
    }

    public void No()
    {
        GameManager.Instance.IsGameStop = true;
        PauseMenuUI.SetActive(true);
     //  GameManager.Instance.AudioManager.PlaySound(AudioType.Button, false);
        Time.timeScale = 0f;
        GamePause = true;
    }

    

    IEnumerator PauseCountDown()
    {
        float curGround = GameManager.Instance.ground.speed;
        GameManager.Instance.ground.speed = 0f;
        PauseMenuUI.SetActive(false);
        GamePause = false;

        _NUM_3.SetActive(true);
     //   GameManager.Instance.AudioManager.PlaySound(AudioType.Button, false);
        yield return new WaitForSeconds(1.0f);
        _NUM_3.SetActive(false);
        _NUM_2.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _NUM_2.SetActive(false);
        _NUM_1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _NUM_1.SetActive(false);
        _START.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _START.SetActive(false);
        GameManager.Instance.IsGameStop = false;
        GameManager.Instance.ground.speed = curGround;
    }
}


