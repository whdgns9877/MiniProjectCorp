using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
     public GameObject[] Obstacles;
    //public GameObject[] Tile1;
    //public GameObject[] Tile2;


    int randNum = 0;
    public void Spawn()
    {
        Debug.Log("스폰 할게요 ^^");
        for (int i = 0; i < Obstacles.Length; i++)
        {
            randNum = Random.Range(0, 3);
            Debug.Log("랜덤 숫자는 : " + randNum);
            if (randNum == 0)
            {
                Obstacles[i].SetActive(true);

            }
            else
            {
                Obstacles[i].SetActive(false);
            }

        }
    }
}
