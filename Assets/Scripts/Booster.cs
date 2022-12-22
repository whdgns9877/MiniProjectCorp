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
        Debug.Log("무적 아이템 먹음!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Do();
        }
    }

    IEnumerator BackGroundScrollSpeedControl(float time)
    {
        process.player.speed *= 0.5f;
        while (true)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                process.player.speed *= 2f;
                yield return null;
            }
        }
    }
}
