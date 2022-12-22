using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform leftPos = null;
    [SerializeField] Transform MiddlePos = null;
    [SerializeField] Transform RightPos = null;
    [SerializeField] Animator anim = null;
    [SerializeField] MeshRenderer myRenderer = null;

    Transform targetPos = null;
    [SerializeField] int myPos = 0;
    public float speed = 0f;

    [SerializeField] bool isGround = true;

    [Header("��ȹ�� �е��� ���� Zone")]
    [SerializeField] float jumpPower = 0f;


    WaitForFixedUpdate time = new WaitForFixedUpdate();
    float deltaTime = 0f;

    [SerializeField] bool isInvincible = false;
    bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = MiddlePos;
    }

    private void Awake()
    {
        deltaTime = Time.deltaTime;
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

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            isJumping = true;
            isGround = false;
            anim.SetBool("isJump", true);
            StartCoroutine(Jump(1.5f));
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
        if (isJumping == false)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, targetPos.transform.position, 0.2f * speed);

        }    
    }

    IEnumerator Jump(float time)
    {
        while (true)
        {
            time -= deltaTime;
            if (time < 0)
            {
                isJumping = false;
                anim.SetBool("isJump", false);
                yield break;
            }
            transform.position += Vector3.up * time * jumpPower * 0.1f;
            yield return time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    void InvinProcess()
    {
        if (isInvincible == true)
            return;
        StartCoroutine(process());
    }

    IEnumerator process()
    {
        isInvincible = true;
        int i = 0;
        for(i = 100; i > 0; i++)
        {
            myRenderer.material.color = new Color(0, 0, 255, i);
            yield return null;
        }
        yield return null;

        for (i = 0; i < 100; i++)
        {
            myRenderer.material.color = new Color(0, 0, 255, i);
            yield return null;
        }
        isInvincible = false;
        yield break;
    }
}
