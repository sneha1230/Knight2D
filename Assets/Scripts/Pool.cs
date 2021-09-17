using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject bullet;
    public GameObject currentbullet;
    Stack<GameObject> BulletPool = new Stack<GameObject>();
    private static Pool instance;
    Animator animator;




    // Update is called once per frame

    public static Pool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Pool>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            CreateBullet();
        }
    }
    public void CreatePool()
    {

        BulletPool.Push(Instantiate(bullet));
        BulletPool.Peek().SetActive(false);
        BulletPool.Peek().name = "Bullet";




    }
    public void AddBulletToPool(GameObject bullettemp)
    {
        BulletPool.Push(bullettemp);
        BulletPool.Peek().SetActive(false);
    }
    public void CreateBullet()
    {
        if (BulletPool.Count == 0)
        {

            CreatePool();
        }
        GameObject temp = BulletPool.Pop();
        temp.SetActive(true);
        temp.transform.position = transform.position;
        currentbullet = temp;
    }
}
