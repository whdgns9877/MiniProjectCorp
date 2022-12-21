using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] 

    public Transform[] backgrounds;
    float speed = 5.0f;
    float leftPosZ = 0f;
    float rightPosZ = 0f;
    float zScreenHalfSize;
    float yScreenHalfSize;

    private void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        zScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosZ = -(zScreenHalfSize * 2);
        rightPosZ = zScreenHalfSize * 2 * backgrounds.Length;
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(0, 0, -speed) * Time.deltaTime;

            if (backgrounds[i].position.z < leftPosZ)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.z + rightPosZ, nextPos.y);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
