using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimpack : MonoBehaviour
{


    private static Collider2D player;
    public GameObject thisItem;
    public GameObject[] possibleDrops;
    public int healValue;
    public AudioClip sndFx;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player = other;
        if (other.tag.Equals("Player"))
        {
            player.GetComponent<PlayerScript>().Heal(healValue);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(sndFx);
            Destroy(this.gameObject, 0.25f);
        }
    }
}