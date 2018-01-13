using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleAI : MonoBehaviour
{


    Rigidbody2D myRigidbody2D;
    Animator anim;
    public Transform player;
    public float speed = 5;
    EnemyScript myScript;
    public float distanceToPlayer;
    public string state = "Walking";
    private bool attacking;
    private float atkAnimLength = 0.167f; // Found in the Animation-  Will be Different for every enemy
    private float atkRange;
    private float detectionRange;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //hitPoints = 10;
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch(UnityException e)
        {
            if (e.GetType().Equals("NullReferenceException"))
            {
                Debug.LogWarning(e.Message);
                player = null;
            }
        }
        myScript = GetComponent<EnemyScript>();
        speed = myScript.speed;
        atkRange = myScript.atkRange;
        detectionRange = myScript.detectionRange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myScript.hitPoints <= 0)//if Dead   
        {//Start Death animations

            myScript.DropItems();
            Destroy(this.gameObject);
        }
        else // Move Character
        {
            if (player != null)
            {
                Vector2 movement = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                float z = Mathf.Atan2((player.transform.position.y - transform.position.y),
                (player.transform.position.x - transform.position.x)) *
                 Mathf.Rad2Deg;
                anim.SetFloat("Angle", z);
                movement.Normalize();
                distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (distanceToPlayer < detectionRange)
                {
                    if (distanceToPlayer < atkRange)
                    {
                        state = "Attacking";
                        anim.SetTrigger("Attacking");
                        myScript.Invoke("HitPlayer", atkAnimLength);
                        anim.SetBool("Walking", false);
                    }

                    if (distanceToPlayer > atkRange)
                    {
                        anim.SetBool("Walking", true);
                        myRigidbody2D.AddForce(movement * speed);
                    }
                }
            }


        }

    }
}
