using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingman : MonoBehaviour
{

    public Transform player;
    private float x = 0.18f;
    public GameObject projectile;
    public float starttimebtwshots;
    private float timebtwshots;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(x, x, x);
        }
        else if (player.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-x, x, x);
        }
        if (timebtwshots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timebtwshots = starttimebtwshots;
        }
        else {
            timebtwshots -= Time.deltaTime;
        }
    }
}
