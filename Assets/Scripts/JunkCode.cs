using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*float z = Mathf.Atan2((player.transform.position.y - transform.position.y),
    (player.transform.position.x - transform.position.x)) * 
    Mathf.Rad2Deg - 90;*/

        //Golem Death Animation
       /*if (GetComponent<Animator>().runtimeAnimatorController.name.Equals("GolemAC"))
        {
            if (!anim.GetBool("Dead"))
            {
                speed = 0;
                Destroy(myRigidbody2D);
                Destroy(GetComponent<BoxCollider2D>());
                anim.SetFloat("DeathAnim", UnityEngine.Random.Range(0, 2));
                anim.SetBool("Dead", true);
                Destroy(this.gameObject, deathTime);
                Invoke("DropItems", deathTime - 0.75f);
            }
        }*/

    }
}




//OLD ENEMY SCRIPT COMPLETE
/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    Rigidbody2D myRigidbody2D;
    Animator anim;
    public Transform player;
    public float speed = 5;

    public int hitPoints;
    public GameObject[] possibleDrops;
    public int length;
    private float deathTime = 2;

    public int HitPoints
    {
        get
        {
            return hitPoints;
        }

        set
        {
            hitPoints = value;
        }
    }
    public void TakeDamage(int damage)
    {
        hitPoints = (hitPoints - damage);

    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //hitPoints = 10;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        length = possibleDrops.Length;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (hitPoints > 0)
        {
            /*float z = Mathf.Atan2((player.transform.position.y - transform.position.y),
                (player.transform.position.x - transform.position.x)) * 
                Mathf.Rad2Deg - 90;*/
/*Vector2 movement = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
float z = Mathf.Atan2((player.transform.position.y - transform.position.y),
(player.transform.position.x - transform.position.x)) *
 Mathf.Rad2Deg;
//transform.eulerAngles = new Vector3(0, 0, z);
anim.SetFloat("Angle", z);
            //BroadcastMessage("Beetle Rotation is " + z);
            movement.Normalize();
            myRigidbody2D.AddForce(movement* speed);
        }
        if (hitPoints <= 0)
        {
            if (GetComponent<Animator>().runtimeAnimatorController.name.Equals("GolemAC"))
            {
                if (!anim.GetBool("Dead"))
                {
                    speed = 0;
                    Destroy(myRigidbody2D);
                    Destroy(GetComponent<BoxCollider2D>());
                    anim.SetFloat("DeathAnim", UnityEngine.Random.Range(0, 2));
                    anim.SetBool("Dead", true);
                    Destroy(this.gameObject, deathTime);
                    Invoke("DropItems", deathTime-0.75f);
                }
            }
            else {
                Destroy(this.gameObject);
                DropItems();
            }
        }
    }
    

    public void DropItems()
{
    if (Random.Range(0, 100) < 20)
    {
        GameObject.Instantiate(possibleDrops[0/*Random.Range(0, possibleDrops.Length-1)*//*],
            GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
}

}*/