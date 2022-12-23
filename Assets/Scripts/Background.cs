using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform spawnPos_1 = null;
    [SerializeField] Transform spawnPos_2 = null;
    [SerializeField] Transform spawnPos_3 = null;
    [SerializeField] Transform spawnPos_4 = null;
    [SerializeField] Transform spawnPos_5 = null;
    [SerializeField] Transform spawnPos_6 = null;
    [SerializeField] Transform spawnPos_7 = null;
    [SerializeField] Transform spawnPos_8 = null;
    [SerializeField] Transform spawnPos_9 = null;

    [SerializeField] GameObject[] objects = null;

    [SerializeField] ObstacleSpwaner spawner = null;

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
                spawner.Spawn();
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.z + rightPosZ, nextPos.y);
                backgrounds[i].position = nextPos;
                GameManager.Instance.RollingCount++;
            }
        }
    }
}
