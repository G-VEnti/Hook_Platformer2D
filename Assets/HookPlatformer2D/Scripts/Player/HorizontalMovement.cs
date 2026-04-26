using UnityEditor.Tilemaps;
using UnityEngine;
public class HorizontalMovement : MonoBehaviour
{
    InputSystem_Actions inputs;
    public float speed;
    public Rigidbody2D playerRB;
    
    private Animator animator;
    private SpriteRenderer playerSprite;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        inputs = new InputSystem_Actions();
        inputs.Enable();
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

            //Vector3 dir = inputs.Player.Move.ReadValue<Vector2>();
            //dir.y = 0;


            playerRB.position += dir * speed * Time.fixedDeltaTime;

        //transform.position += dir * speed * Time.fixedDeltaTime;
    }
}
