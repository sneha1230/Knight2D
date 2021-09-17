using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float x;
    public float y;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= x)
        {
            spriteRenderer.flipX = false;
            speed = 1;
        }
        if (transform.position.x >= y)
        {
            spriteRenderer.flipX = true;
            speed = -1;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
