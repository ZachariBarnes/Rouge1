using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float speed = 10;
    float rollspd;
    float tmpspeed;
    Rigidbody2D myRigidbody;
    Animator anim;
    bool rolling;
    int count = 0;
    int dodgeCD = 120; // CD Stand for Coolddown
    //BoxCollider2D collisionBox;
    public GameObject weapon;
    //GameObject currentObject;
    private int maxHealth;
    public Slider playerHealth;
    //private float flashspeed = 5f;
    //private Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //AudioSource playerAudio;
    public AudioClip hitSnd;
    private AudioSource Audio;


    public int hitPoints=100;
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
    public void Heal(int healAmt)
    {
        hitPoints = hitPoints + healAmt;
        CalculateHealth();
    }

    public void TakeDamage(int damage)
    {
        Audio = GetComponent<AudioSource>();
        if (hitSnd != null)
        {
            Audio.PlayOneShot(hitSnd);
        }
        hitPoints = (hitPoints - damage);
        CalculateHealth();

    }

    void OnGUI()
    {


    }

    void CalculateHealth()
    {
        playerHealth.value=hitPoints;// / maxHealth;

    }



    // Use this for initialization
    void Start () {
        maxHealth = 100;
        //currentObject = GetComponent<GameObject>();
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerHealth = FindObjectOfType<Slider>();
        rolling = false;
        rollspd = speed * 2;
        tmpspeed = speed;
        hitPoints = maxHealth;       //collisionBox = GetComponent<BoxCollider2D>();
        playerHealth.maxValue = maxHealth;
        CalculateHealth();
        Audio = GetComponent<AudioSource>();

        myRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        myRigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;


    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (hitPoints <= 0)
        {//Need to figure out how to handle loss since all enemies refernece the player. Would require a billion null checks or deleting all enemies when the player dies.
            //Possibly Delete everything and move directly to a game over Scene.
            //Destroy(this.gameObject);
        }

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition,
        //  Vector3.forward);
        // for this example, the bar display is linked to the current time,
        // however you would set this value based on your desired display
        // eg, the loading progress, the player's health, or whatever.

        if (count <= 0)
        {
            CheckEvade();
        }
        else
        {
            count--;
        }

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Rolling", rolling);
            anim.SetFloat("Angle", angle);
        }
        else
        {
            anim.SetBool("Rolling", rolling);
            anim.SetBool("Walking", false);
            anim.SetFloat("Angle", angle);
            myRigidbody.velocity = Vector2.zero;
        }

        float input = Input.GetAxis("Vertical");
        //rigidbody.AddForce(gameObject.transform.up * speed * input);
        float input2 = Input.GetAxis("Horizontal");
        //rigidbody.AddForce(gameObject.transform.right * speed * input2);
        //rigidbody.MovePosition

        transform.Translate(gameObject.transform.up * (speed * input) * Time.deltaTime);
        transform.Translate(gameObject.transform.right * (speed * input2) *  Time.deltaTime);
        //rigidbody.MovePosition((rigidbody.position + movement_vector * speed) * Time.deltaTime);
    }

    private void CheckEvade()
    {
        if (Input.GetButtonDown("Jump") && dodgeCD <= 0)
        {
            Evade();
        }
        else
        {//This should be refactored to only occur once instead of every frame that we're not evading.
            speed = tmpspeed;
            rolling = false;
            dodgeCD--;
            //collisionBox.size = collisionBox.size * 5;
        }
    }
    private void Evade()
    {
        rolling = true;
        tmpspeed = speed;
        speed = rollspd;
        count = 30; 
        dodgeCD = 120; //Start Cooldown
        //collisionBox.size = collisionBox.size / 5;
    }

    // Update is called once per frame
    void FixedUpdate () {
      
    }
}
