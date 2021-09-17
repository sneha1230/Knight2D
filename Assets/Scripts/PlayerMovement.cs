using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float playerSpeed;
    public float jumpSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public bool playerMove = true;
    public static PlayerMovement instance;

    public void Awake()
    {

        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerRB.velocity = new Vector2(playerSpeed, 0);
                spriteRenderer.flipX = false;

                animator.SetTrigger("Walk");

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerRB.velocity = new Vector2(-playerSpeed, 0);
                spriteRenderer.flipX = true;


                animator.SetTrigger("Walk");

            }

           else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
                animator.SetTrigger("Jump");
            }
        }

    }
    private void Jump()
    {
        playerRB.velocity = new Vector2(0, jumpSpeed);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Score.instance.IncrementScore();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spike")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
    
}