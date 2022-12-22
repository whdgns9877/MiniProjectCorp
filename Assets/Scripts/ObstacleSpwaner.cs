using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
    public GameObject[] Obstacles;

    int randNum = 0;
    public void Spawn()
    {
        for (int i = 0; i < Obstacles.Length; i++)
        {
            randNum = Random.Range(0, 3);
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
