using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour, IProcess
{
    IProcess process = null;
    void Start()
    {
        process = gameObject.GetComponent<IProcess>();
    }

    void Do()
    {
        Invincivle();
    }

    void Invincivle()
    {
        process.ground.speed *= 1.5f;
        process.player.gameObject.SendMessage("InvinProcess", SendMessageOptions.DontRequireReceiver);
        Debug.Log("���� ������ ����!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Do();
        }
    }
}
