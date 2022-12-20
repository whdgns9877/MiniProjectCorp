using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform MiddlePos;
    [SerializeField] Transform RightPos;

    [SerializeField] float speed = 0f;

    Transform targetPos = null;
    [SerializeField] int myPos = 0;

    ObjectPool pool = new ObjectPool();
    // Start is called before the first frame update
    void Start()
    {
        targetPos = MiddlePos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myPos = --myPos < -1 ? -1 : myPos;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myPos = ++myPos > 1 ? 1 : myPos;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject instObj = pool.Make();
            instObj.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //pool.Retrieve();
        }

        switch (myPos)
        {
            case -1:
                targetPos = leftPos;
                break;
            case 0:
                targetPos = MiddlePos;
                break;
            case 1:
                targetPos = RightPos;
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, targetPos.transform.position, 0.2f * speed);
    }
}
