using UnityEngine;
public class HorizontalMovement : MonoBehaviour
{
    InputSystem_Actions inputs;
    public float speed;
    public Rigidbody2D playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = inputs.Player.Move.ReadValue<Vector2>();
        dir.y = 0;

        //Vector3 dir = inputs.Player.Move.ReadValue<Vector2>();
        //dir.y = 0;


        playerRB.position += dir * speed * Time.fixedDeltaTime;

        //transform.position += dir * speed * Time.fixedDeltaTime;
    }
}
