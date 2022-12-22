using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, IProcess
{
    //------------------------------------------------------//
    [SerializeField] GameObject[] debrises = null;
    [SerializeField] float exposiveForce = 0f;
    [SerializeField] Vector3 offset = Vector3.zero;
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
        if(process.player.isInvincible == true)
            Crash();
        else 
            StartCoroutine(playerSpeedController(3f));
    }

    IEnumerator playerSpeedController(float time)
    {
        process.player.speed = 0.5f;
        while (true)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                process.player.speed = 2f;
                yield return null;
            }
        }
    }

    private void Crash()
    {
        Rigidbody[] rigidbodies = new Rigidbody[debrises.Length];
        for (int i = 0; i < debrises.Length; i++)
        {
            debrises[i].SetActive(true);
            rigidbodies[i] = debrises[i].GetComponent<Rigidbody>();
            debrises[i].transform.SetParent(null);
        }

        for(int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].AddExplosionForce(exposiveForce, transform.position + offset, 10f);
        }
        gameObject.SetActive(false);
    }
}
