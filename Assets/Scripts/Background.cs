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
            }
        }
    }

    private void RandSpawn()
    {
        for (int i = 0; i < randArray.Length; ++i)
        {
            Debug.Log($"{i + 1}��° ���� : {randArray[i]}");
            if (0 == randArray[i])
            {
                Tile1.SetActive(true);
                // Debug.Log("Ÿ��1����");
            }

            if (1 == randArray[i])
            {
                Tile2.SetActive(true);
                // Debug.Log("Ÿ��2 ����");
            }

            if (2 == randArray[i])
            {
                Tile3.SetActive(true);
                // Debug.Log("1��¶�");
            }

            if (3 == randArray[i])
            {
                Tile4.SetActive(true);
                // Debug.Log("1��¶�");
            }

            if (4 == randArray[i])
            {
                Tile5.SetActive(true);
                //  Debug.Log("1��¶�");
            }

            if (5 == randArray[i])
            {
                Tile6.SetActive(true);
                //  Debug.Log("1��¶�");
            }

            if (7 == randArray[i])
            {
                Tile7.SetActive(true);
                //   Debug.Log("1��¶�");
            }

            if (8 == randArray[i])
            {
                Tile8.SetActive(true);
                //  Debug.Log("1��¶�");
            }
                // ������ ���õ��� ���� Ÿ�ϵ��� ��Ƴ��´�(�迭�̵� ����Ʈ�� �ڷᱸ���� ��������)
                // �ش� �ڷᱸ���� ���� ������ŭ �ݺ����� ���Ƽ� �ش� ��ü���� ���ش�( setactive(false))
                // SetActive�� GameObject Ŭ������ static �Լ��̹Ƿ� GameObject�� �־�����մϴ�
                //gameObject.SetActive(false);
        }
    }
}
