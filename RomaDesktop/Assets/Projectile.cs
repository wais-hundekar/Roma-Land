using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    private Vector2 target;
    public float speed;
    public int damage;
  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    target = new Vector2(player.position.x * 10, player.position.y * 10);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
    }
    void DestroyProjectile() {
        Destroy(gameObject);
        Debug.Log("wysg");
            }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            other.GetComponent<Movement>().TakeDamage(damage);
        }else if(other.CompareTag("Ground"))
        {
            DestroyProjectile();
        }
    }
}
