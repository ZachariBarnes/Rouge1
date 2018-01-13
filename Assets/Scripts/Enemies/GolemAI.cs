using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GolemAI : MonoBehaviour {


    Rigidbody2D myRigidbody2D;
    Animator anim;
    public Transform player;
    public float speed = 5;
    EnemyScript myScript;
    private float deathTime = 2;
    private float distanceToPlayer;
    private string state = "Walking";
    private bool attacking;
    private float atkAnimLength = 0.583f; // Found in the Animation-  Will be Different for every enemy
    private float atkRange;
    private float detectionRange;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myScript = GetComponent<EnemyScript>();
        speed = myScript.speed;
        atkRange = myScript.atkRange;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        atkAnimLength = myScript.atkAnimLength;
        detectionRange = myScript.detectionRange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myScript.hitPoints <= 0)//if Dead   
        {//Start Death animations
            if (!anim.GetBool("Dead"))  //Unless Death Animation is already started
            {
                speed = 0; // Stop moving
                Destroy(myRigidbody2D); //Remove collisions and Rigid body
                Destroy(GetComponent<BoxCollider2D>());
                anim.SetFloat("DeathAnim", UnityEngine.Random.Range(0, 2)); // Randomly select a Death animation to play
                anim.SetBool("Dead", true); // Start the animation
                GetComponent<SpriteRenderer>().sortingOrder=2;
                //Destroy(this.gameObject, 10);//Destroy this objext in X seconds
                myScript.Invoke("DropItems", deathTime - 0.75f); //Roll to Drop items before destruction
            }

        }
        else // Move Character
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
                if (distanceToPlayer < atkRange && !state.Equals("Attacking"))
                {
                    state = "Attacking";
                }
                if (distanceToPlayer > atkRange)
                {
                    state = "Walking";
                }
                switch (state)
                {
                    case "Walking":
                        {
                            anim.SetBool("Walking", true);
                            myRigidbody2D.AddForce(movement * speed);
                            break;
                        }
                    case "Attacking":
                        {
                            anim.SetTrigger("AttackTrigger");
                            anim.SetBool("Walking", false);
                            //StartCoroutine(Attacking());
                            myScript.Invoke("HitPlayer", atkAnimLength - 0.08f);
                            break;
                        }
                }
            }

        }
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(atkAnimLength);
        // trigger the stop animation events here
        anim.SetBool("Attacking", false);
        anim.SetBool("Walking", true);
    }
}

