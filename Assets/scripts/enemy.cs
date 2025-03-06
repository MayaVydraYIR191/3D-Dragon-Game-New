using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int enemyHealth = 10;
    private Animator anim;
    public float speed;

    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    private CharacterController control;
    private bool groundedEnemy;

    Transform player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;


    void Start()
    {
        control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector3.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (enemyHealth == 0)
        {
            anim.SetBool("isDead", true);
            gameObject.SetActive(false);

        }
        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            Goback();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.SetBool("isAttacking", true);
            enemyHealth = enemyHealth - 1;
        }
        if(other.gameObject.tag == "Ground")
        {
            groundedEnemy = control.isGrounded; 
        }
    }
    void Chill()
    {
        anim.SetBool("isWalking", true);
        
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }


    void Angry()
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", true);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Goback()
    {
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

}
