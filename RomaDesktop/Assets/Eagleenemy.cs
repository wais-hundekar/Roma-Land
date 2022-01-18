using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagleenemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float sensingDistance;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;

    public Transform player;

    public Transform Homing;

    public Animator anime;

    public int health;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }



        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < sensingDistance)
        {
            anime.SetBool("IsRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (player.position.x > transform.position.x)
            {
                //face right
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (player.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            anime.SetBool("IsRunning", false);

            if (player.position.x > transform.position.x)
            {
                //face right
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (player.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(1, 1, 1);
            }


            if (timeBtwAttack <= 0)
            {
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Movement>().TakeDamage(damage);
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }





        }
        else if (Vector2.Distance(transform.position, player.position) > sensingDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, Homing.position, speed * Time.deltaTime);
            if (Homing.position.x > transform.position.x)
            {
                //face right
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Homing.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(1, 1, 1);
            }
            
        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }

        ;




    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damageTaken");



    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
