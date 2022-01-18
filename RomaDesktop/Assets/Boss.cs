using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;

    public Slider healthBar;

    public Transform rightPlace;
        public Transform leftPlace;
    private bool isMovingRight = false;
    public float speed;
    public int damage;

    public Animator anime;

    private float lifeTime = 0.5f;

    public GameObject dialogueManager;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (health <= 0)
        {
            dialogueManager.GetComponent<DialogueBossDeath>().enabled = true;
            dialogueManager.GetComponent<Dialogue>().enabled = false;

        }

        healthBar.value = health;

        if(isMovingRight == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPlace.position, speed * Time.deltaTime);
            if(transform.position == leftPlace.position)
            {
                isMovingRight = true;
            }
        }
        else if(isMovingRight == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPlace.position, speed * Time.deltaTime);
            if(transform.position == rightPlace.position)
            {
                isMovingRight = false;
            }
        }
    }


    

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damageTaken");



    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Movement player = hitInfo.GetComponent<Movement>();
        if (player != null)
        {
            player.TakeDamage(damage);

        }
    }
    public void AfterBossDeath()
    {

        Debug.Log("uefioefiorjoij");
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Destroy(gameObject, lifeTime);

        anime.SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
}
