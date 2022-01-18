using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    static int sceneNumber;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extraJumpValue;

    public Animator anime;

    public int health;

    public Slider healthBar;

    private ButtonCommands buttonCommands;

    private string sceneName;

    // Start is called before the first frame update
 
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        buttonCommands = GameObject.FindObjectOfType<ButtonCommands>();

        Scene currentScene = SceneManager.GetActiveScene();

       sceneName = currentScene.name;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
            anime.SetBool("IsJumping", false);
        }
        else
        {
            anime.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");

        }
        
        anime.SetFloat("Speed", Mathf.Abs(moveInput));

        if (health <= 0)
        {
            Destroy(gameObject);
            if(sceneName == "Boss Battle")
            {
              sceneNumber = 1;
                Debug.Log(sceneNumber);
                buttonCommands.UpdateScene(sceneNumber);
                SceneManager.LoadScene(sceneNumber);

            }
            else if (sceneName == "ThirdLevel") {
                sceneNumber = 2;
                Debug.Log(sceneNumber);
                buttonCommands.UpdateScene(sceneNumber);
                SceneManager.LoadScene("Game Over");
                Debug.Log(sceneNumber);
            }
            else
            {
                sceneNumber = 1;
            }
            
        }

        healthBar.value = health;


    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damageTaken");



    }

}
