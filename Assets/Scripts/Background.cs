using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject[] objects = null;
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject Tile4;
    public GameObject Tile5;
    public GameObject Tile6;
    public GameObject Tile7;
    public GameObject Tile8;
    public GameObject Tile9;

    int[] randArray = new int[10]; 
    public Transform[] backgrounds;
    public float speed { get; set; } = 0f;

    float leftPosZ = 0f;
    float rightPosZ = 0f;
    float zScreenHalfSize;
    float yScreenHalfSize;

    private void Awake()
    {
        
    }

    private void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        zScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosZ = -(zScreenHalfSize * 5);
        rightPosZ = zScreenHalfSize * 5 * backgrounds.Length;
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(0, 0, -speed) * Time.deltaTime;

            if (backgrounds[i].position.z < leftPosZ)
            {
                randArray = ObstacleSpwaner.RandomNumbers(15, 10);
                RandSpawn();
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.z + rightPosZ, nextPos.y);
                backgrounds[i].position = nextPos;
                GameManager.Instance.RollingCount++;
                if (GameManager.Instance.RollingCount == 10)
                {
                    // 게임매니저의 게임 끝내는 함수 호출
                    GameManager.Instance.GameFinish();
                }
            }
        }
    }

    private void RandSpawn()
    {
        for (int i = 0; i < randArray.Length; ++i)
        {
            Debug.Log($"{i + 1}번째 난수 : {randArray[i]}");
            if (0 == randArray[i])
            {
                Tile1.SetActive(true);
                // Debug.Log("타일1떳냐");
            }

            if (1 == randArray[i])
            {
                Tile2.SetActive(true);
                // Debug.Log("타일2 떴냐");
            }

            if (2 == randArray[i])
            {
                Tile3.SetActive(true);
                // Debug.Log("1출력띠");
            }

            if (3 == randArray[i])
            {
                Tile4.SetActive(true);
                // Debug.Log("1출력띠");
            }

            if (4 == randArray[i])
            {
                Tile5.SetActive(true);
                //  Debug.Log("1출력띠");
            }

            if (5 == randArray[i])
            {
                Tile6.SetActive(true);
                //  Debug.Log("1출력띠");
            }

            if (7 == randArray[i])
            {
                Tile7.SetActive(true);
                //   Debug.Log("1출력띠");
            }

            if (8 == randArray[i])
            {
                Tile8.SetActive(true);
                //  Debug.Log("1출력띠");
            }
                // 위에서 선택되지 않은 타일들을 모아놓는다(배열이든 리스트든 자료구조는 본인취향)
                // 해당 자료구조에 쌓인 갯수만큼 반복문을 돌아서 해당 객체들을 꺼준다( setactive(false))
                // SetActive는 GameObject 클래스의 static 함수이므로 GameObject를 넣어줘야합니다
                //gameObject.SetActive(false);
        }
    }
}
