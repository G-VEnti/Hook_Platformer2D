using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
public class HorizontalMovement : MonoBehaviour
{
    InputSystem_Actions inputs;
    public float speed;
    public float bottomLimit;
    public Rigidbody2D playerRB;

    private Animator animator;
    private SpriteRenderer playerSprite;
    //private GroundDetector groundDetector;
    //private Vector2 platformLastPosition;
    //private Vector2 platformDelta;
    private Collider2D currentChest;

    public GameObject currentCheckPoint;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        //groundDetector = GetComponent<GroundDetector>();
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    private void Update()
    {
        if (currentChest != null && GameManager.instance.keyObtained)
        {
            if (inputs.Player.Interact.WasPressedThisFrame())
            {
                Destroy(currentChest.gameObject);
                currentChest = null;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = inputs.Player.Move.ReadValue<Vector2>();
        dir.y = 0;

        if (dir.x > 0 || dir.x < 0) animator.SetBool("isRunning", true);
        else animator.SetBool("isRunning", false);

        if (dir.x < 0) playerSprite.flipX = true;
        else if (dir.x > 0) playerSprite.flipX = false;

        if (transform.position.y < bottomLimit) transform.position = currentCheckPoint.transform.position;


        //if (groundDetector.rayHit.collider.gameObject.CompareTag("MobilePlatform"))
        //{
        //    platformDelta = (Vector2)groundDetector.rayHit.collider.transform.position - platformLastPosition;
        //    platformLastPosition = groundDetector.rayHit.collider.transform.position;
        //}
        //else platformDelta = Vector2.zero;

        playerRB.position += dir * speed * Time.fixedDeltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Chest"))
        {
            currentChest = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Chest"))
        {
            currentChest = null;
        }
    }
}
