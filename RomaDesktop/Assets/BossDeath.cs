using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{

    public Animator anime;

    private float lifeTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("uefioefiorjoij");
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Destroy(gameObject, lifeTime);

        anime.SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }


    // Update is called once per frame
    void Update()
    {
    }
}
