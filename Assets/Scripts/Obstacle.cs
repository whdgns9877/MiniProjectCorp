using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, IProcess
{
    IProcess process = null;
    void Start()
    {
        process = gameObject.GetComponent<IProcess>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Do();
        }
    }

    private void Do()
    {
        playerSpeedController(3f);
    }

    IEnumerator playerSpeedController(float time)
    {
        process.player.speed *= 0.5f;
        while (true)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                process.player.speed *= 2f;
                yield return null;
            }
        }
    }
}
