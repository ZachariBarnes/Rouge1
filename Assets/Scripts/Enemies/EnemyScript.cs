using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private GameObject player;
    public int hitPoints;
    public GameObject[] possibleDrops;
    private int length;
    public float knockBackDistance;
    public float atkRange;
    public int damage;
    public float atkAnimLength;
    public float speed;
    PlayerScript playerScript;
    private bool attacking = false;
    public AudioClip hitSnd;
    private AudioSource Audio;
    public float detectionRange= 10;

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
        if (hitSnd != null)
        {
            Audio.PlayOneShot(hitSnd);
        }
        hitPoints = (hitPoints - damage);
    }

    // Use this for initialization
    void Start()
    {
        length = possibleDrops.Length;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<PlayerScript>();
        }
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void DropItems()
    {
        if (Random.Range(0, 100) < 20)
        {
            GameObject.Instantiate(possibleDrops[Random.Range(0, length)],
                GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            
        }
    }

    public void HitPlayer()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= atkRange)
            {
                Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                player.GetComponent<Rigidbody2D>().AddForce((direction) * knockBackDistance);
                playerScript = player.GetComponent<PlayerScript>();
                if (!attacking)
                {
                    if (playerScript != null && playerScript.hitPoints > 0)
                    {
                        attacking = true;
                        Invoke("DamagePlayer", atkAnimLength);
                    }
                }
            }
        }

    }


    private void DamagePlayer()
    {
        if (player != null)
        {
            playerScript.TakeDamage(damage);
        }
        attacking = false;
    }
}

