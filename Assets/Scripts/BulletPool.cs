using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    Rigidbody2D bulletRB;
    float bulletSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        bulletRB.velocity = Vector3.right * bulletSpeed;


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("BulletAddToPool");
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
        }



    }
    IEnumerator BulletAddToPool()
    {
        yield return new WaitForSeconds(1);

        if (bulletRB.gameObject.name == "Bullet")
        {

            Pool.Instance.AddBulletToPool(bulletRB.gameObject);


        }
    }
}
