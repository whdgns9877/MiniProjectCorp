using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPause = false;
    private static GameManager instance = null;

    public static GameManager Instance { get { return instance; } }

    //[SerializeField] private AudioManager audioManager = null;
    //public AudioManager AudioManager { get { return audioManager; } }
    public Player player = null;
    public Background ground= null;

    public int RollingCount { get; set; } = 0;

    public GameObject _NUM_1;
    public GameObject _NUM_2;
    public GameObject _NUM_3;
    public GameObject _START;
    public GameObject _Tutorial;

    private int score = 0;
    private int bestScore = 0;
    private float time = 0;
    public int BestScore {
        get 
        {
            return 
                bestScore = PlayerPrefs.GetInt("bestScore") < score ? score : PlayerPrefs.GetInt("bestScore"); 
        }
    }

    public bool IsGameStop = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            return;
    }

    private void Start()
    {
        IsGameStop = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ground = GameObject.Find("Backgroundtest").GetComponent<Background>();
        _Tutorial.SetActive(true);
        _NUM_1.SetActive(false);
        _NUM_2.SetActive(false);
        _NUM_3.SetActive(false);
        _START.SetActive(false);
        ground.speed = 0f;
        StartCoroutine(CountDown());
        Debug.Log("카운트다운 코루틴");
    }

    IEnumerator CountDown()
    {
        Debug.Log("카운트 시작");
     //   GameManager.Instance.AudioManager.PlaySound(AudioType.CountDown, false);
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
        IsGameStop = false;
        yield return new WaitForSeconds(1.0f);
        _START.SetActive(false);
        _Tutorial.SetActive(false);
        ground.speed = 5f;
        Init(player, ground);
        yield return new WaitForSeconds(0.5f);
     //   GameManager.Instance.AudioManager.PlaySound(AudioType.GameScene, true);
    }

    private void Update()
    {
        if (IsPause == true)
        {
            
        }
    }

    private void Init(Player player, Background ground)
    {
        StartCoroutine(SpeedControl(3f));
        SetUI();
        ground.speed = 5;
    }

    private void SetUI()
    {
        score = 0;
        time = 0;
    }

    public void ScoreProcess(int score)
    {

    }

    IEnumerator SpeedControl(float startControl)
    {
        time = 0;
        while(true)
        {
            if(time > startControl)
            {
                ground.speed = 8;
                yield break;
            }
            time += Time.deltaTime;

            yield return null;
        }
    }

    public void GameFinish()
    {
        // 맵 스크롤 카운트가 일정 수치가 되어서 게임을끝내는함수
        // UI 처리와 BestScore 등등 처리할거 여기서 해주면 됩니다.
    }
}
