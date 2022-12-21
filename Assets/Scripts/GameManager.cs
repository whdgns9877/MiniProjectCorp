using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance { get { return instance; } }

    public Player player = null;
    public Background ground= null;

    public int RollingCount { get; set; } = 0;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ground = GameObject.Find("Backgroundtest").GetComponent<Background>();

        ground.speed = 0f;
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        Debug.Log(3);
        yield return new WaitForSeconds(1.0f);
        Debug.Log(2);
        yield return new WaitForSeconds(1.0f);
        Debug.Log(1);
        yield return new WaitForSeconds(1.0f);
        print("Game Start!!");
        ground.speed = 5f;
        Init(player, ground);
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
}
