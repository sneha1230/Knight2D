using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    public float jumpSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public bool playerMove = true;
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

}
