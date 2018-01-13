using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    GameObject target;
    public int damage = 10;

	// Use this for initialization
	void Start () {		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            EnemyScript dmgScript = other.gameObject.GetComponent<EnemyScript>() as EnemyScript;
            dmgScript.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("Spawner"))
        {
            Spawner dmgScript = other.gameObject.GetComponent<Spawner>() as Spawner;
            dmgScript.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            //Destroy(other.gameObject);
            EnemyScript dmgScript = other.gameObject.GetComponent<EnemyScript>() as EnemyScript;
                dmgScript.TakeDamage(damage);
                Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
