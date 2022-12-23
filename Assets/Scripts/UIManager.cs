using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool GamePause = false;
    public GameObject PauseMenuUI;
    public GameObject _NUM_1;
    public GameObject _NUM_2;
    public GameObject _NUM_3;
    public GameObject _START;
    

    public void SceneChange()
    {
        SceneManager.LoadScene("CMJScene");
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("�����ߵ�");
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause == true)
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
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    IEnumerator PauseCountDown()
    {
        float curGround = GameManager.Instance.ground.speed;
        GameManager.Instance.ground.speed = 0f;
        PauseMenuUI.SetActive(false);
        GamePause = false;
        yield return new WaitForSeconds(1.0f);
        _NUM_3.SetActive(true);
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
        GamePause = true;
        GameManager.Instance.ground.speed = curGround;
    }
}


