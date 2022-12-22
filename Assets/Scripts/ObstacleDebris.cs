using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDebris : MonoBehaviour
{
    [SerializeField] GameObject[] debrises = null;
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] float exposiveForce = 0f;

    private void OnEnable()
    {
        Rigidbody[] rigidbodies = new Rigidbody[debrises.Length];
        for (int i = 0; i < debrises.Length; i++)
        {
            debrises[i].SetActive(true);
            rigidbodies[i] = debrises[i].GetComponent<Rigidbody>();
            debrises[i].transform.SetParent(null);
        }

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].AddExplosionForce(exposiveForce, transform.position + offset, 10f);
        }

        Destroy(gameObject);
    }
}
