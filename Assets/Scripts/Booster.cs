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
        GameManager.Instance.AudioManager.PlaySound(AudioType.Booster, false);
    }

    void Invincivle()
    {
        process.ground.speed = 30f;
        process.player.gameObject.SendMessage("InvinProcess", SendMessageOptions.DontRequireReceiver);
        Invoke(nameof(ReSetBackGroundSpeed), 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Do();
        }
    }

    void ReSetBackGroundSpeed()
    {
        process.ground.speed = 8f;
    }
}
