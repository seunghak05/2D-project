using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{

    public AudioClip deathClip; // Assign this in the inspector
    public float jumpForce = 700f;

    private int jumpCount = 0;

    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;

    private Animator animator;

    private AudioSource playerAudio;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.linearVelocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y > 0)
        {

            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);


    }
    private void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRigidbody.linearVelocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            isGrounded = false;
    }
}


