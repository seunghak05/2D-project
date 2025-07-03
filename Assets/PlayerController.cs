using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioClip deathClip; // Assign this in the inspector
    public float junpForce = 700f;

    private int jumpcount = 0;

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

        if (Input.GetMouseButtonDown(0) && jumpcount < 2)
        {
            jumpcount++;
            playerRigidbody.linearVelocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, junpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y > 0)
        {

            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }

        animator.SetBool("isGrounded", isGrounded);


    }
    
    
}
