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
    [SerializeField] GameObject InvincibleEff = null;

    Transform targetPos = null;
    [SerializeField] int myPos = 0;
    public float speed = 0f;

    [SerializeField] bool isGround = true;

    [Header("��ȹ�� �е��� ���� Zone")]
    [SerializeField] float jumpPower = 0f;


    WaitForFixedUpdate frameTime = new WaitForFixedUpdate();
    float deltaTime = 0f;

    public bool isInvincible = false;
    bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
        targetPos = MiddlePos;
    }

    private void Awake()
    {
        deltaTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping == true)
            return;
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
         //   GameManager.Instance.AudioManager.PlaySound(AudioType.Jump, false);
         //  GameManager.Instance.AudioManager.RunSound.Stop();
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
             //   GameManager.Instance.AudioManager.PlaySound(AudioType.Run, true);
                isJumping = false;
                anim.SetBool("isJump", false);
                
                yield break;
            }
            transform.position += Vector3.up * time * jumpPower * 0.1f;
            yield return frameTime;
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
        StartCoroutine(process(3f));
    }

    IEnumerator process(float time)
    {
        isInvincible = true;
        anim.SetFloat("runSpeed", 1.5f);
        InvincibleEff.SetActive(true);
        while (true)
        {
            time -= deltaTime;
            if(time < 0)
            {
                anim.SetFloat("runSpeed", 1f);
                InvincibleEff.SetActive(false);
                isInvincible = false;
                yield break;
            }
            yield return frameTime;
        }
    }
}
