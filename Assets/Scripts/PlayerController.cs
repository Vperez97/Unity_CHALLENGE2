using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{


    public float speed;
    public float jumpForce;
    public Text countText;          //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText;
    public Text livesText;
    private int lives;
    private int count;
    private Rigidbody2D rb2d;
    public AudioClip winMusic;
    public AudioClip BgMusic;
    public AudioSource musicSource;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        lives = 3;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        winText.text = "";

        //Call our SetCountText function which will update the text with the current value for count.
        SetCountText();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        musicSource.clip = BgMusic;
        musicSource.Play();
        musicSource.loop = true;


    }

    void Update()
    {

      
   }


            void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
        }
        if (count == 4)
        {
            transform.position = new Vector3(41.19f, -2.46f, transform.position.z);
            lives = 3;
            SetCountText();
        }
        if (count == 8)
        {
            musicSource.clip = winMusic;
            musicSource.Play();
            musicSource.loop = true;
        }
    }


    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        livesText.text = "Lives: " + lives.ToString();
        countText.text = "Count: " + count.ToString();

        //Check if we've collected all 12 pickups. If we have...
        if (count >= 8 && lives>=1)
        {
            //... then set the text property of our winText object to "You win!"
            winText.text = "You win!";
          
        }
        else if (lives <= 0)
        {
            winText.text = "You lose!";
        }

    }

}

