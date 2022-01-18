using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour

    
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
   



        void OnTriggerEnter2D (Collider2D hitInfo)
    {

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        Boss boss = hitInfo.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);

        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);

    }
   
}

