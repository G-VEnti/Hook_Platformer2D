using UnityEngine;

public class Jump : MonoBehaviour
{
    InputSystem_Actions inputs;    
    public float force;
    public Rigidbody2D playerRB;
    GroundDetector groundDetectorScript;
    Animator animator;
    public bool isGoingUp;
    public bool isGoingDown;
    AudioSource audioSource;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        groundDetectorScript = GetComponent<GroundDetector>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.Player.Jump.WasPressedThisFrame() && groundDetectorScript.isGrounded)
        {
            playerRB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            audioSource.Play();
        }

        isGoingUp = (!groundDetectorScript.isGrounded && playerRB.linearVelocityY > 0);
        isGoingDown = (!groundDetectorScript.isGrounded && playerRB.linearVelocityY < 0);
        animator.SetBool("isGoingUp", isGoingUp);
        animator.SetBool("isGoingDown", isGoingDown);
    }
}
