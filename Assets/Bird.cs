using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private AudioSource audioSource;
    public static bool soundToggle;

    private Rigidbody2D rb;
    private float moveInput;
    private float BirdJumpX = 0;
    public LayerMask groundMask;
    public bool canJump = false;
    private float speed = 1.6f;
    private bool isGrounded;

    private float maxjump = 13.0f;
    public float jumpValue = 0.0f;
    private Vector2 Playerpos;

    private Animator anim;

    // jumpvalue를 통해 계산해서, x 값에 맞는 너비에 기둥이 생기고 그에 맞는 y값을 가진 높이기둥생성
    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundToggle = true;
        audioSource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        Playerpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(Playerpos.x, Playerpos.y), new Vector2(0.9f, 0.4f));
    }
    */

    void Update()
    {
        //transform.y + 0.2f , (0.9,0.4)
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y+0.2f), new Vector2(0.9f, 0.4f), 0f, groundMask);

        if (Input.GetMouseButton(0) && isGrounded && canJump)
        {
            anim.SetBool("isSit", true);
            anim.SetBool("isJump", false);
            jumpValue += 0.25f*Time.deltaTime*60;

            if (jumpValue >= maxjump)
            {
                jumpValue = maxjump;
            }

        }

        if (Input.GetMouseButtonUp(0) && isGrounded)
        {
            if (soundToggle)
            {
                audioSource.Play();
            }


            BirdJumpX = 0.05f * (Score.score / 10);
            if (BirdJumpX >= 0.6f)
            {
                BirdJumpX = 0.6f;
            }

            anim.SetBool("isJump", true);
            anim.SetBool("isSit", false);
            rb.AddForce(Vector2.up * jumpValue, ForceMode2D.Impulse);
            rb.AddForce(Vector2.right * (1.9f + BirdJumpX), ForceMode2D.Impulse);
            Invoke("ResetJump", 0.1f);
        }

        if (isGrounded && canJump == false)
        {
            canJump = true;
        }

        if (isGrounded)
        {
            speed = 1.6f + 0.05f * (Score.score / 5);
            if (speed>=2.2f) {
                speed = 2.2f;
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            transform.position += new Vector3(0.05f,0,0);
        }
    }

}

