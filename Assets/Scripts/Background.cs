using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject[] objects = null;

    int[] randArray = new int[10]; 
    public Transform[] backgrounds;
    public float speed { get; set; } = 0f;

    float leftPosZ = 0f;
    float rightPosZ = 0f;
    float zScreenHalfSize;
    float yScreenHalfSize;

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
            switch (randArray[i])
            {
                case 0:
                    objects[0].SetActive(true);
                    break;
                case 1:
                    objects[1].SetActive(true);
                    break;
                case 2:
                    objects[2].SetActive(true);
                    break;
                case 3:
                    objects[3].SetActive(true);
                    break;
                case 4:
                    objects[4].SetActive(true);
                    break;
                case 5:
                    objects[5].SetActive(true);
                    break;
                case 6:
                    objects[6].SetActive(true);
                    break;
                case 7:
                    objects[7].SetActive(true);
                    break;
                case 8:
                    objects[8].SetActive(true);
                    break;
                case 9:
                    objects[9].SetActive(true);
                    break;
                case 10:
                    objects[10].SetActive(true);
                    break;
                case 11:
                    objects[11].SetActive(true);
                    break;
            }
        }
    }

    public void ActiveFalse()
    {
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }
}
