using UnityEngine;

public class Jump : MonoBehaviour
{
    InputSystem_Actions inputs;
    
    public float force;

    public Rigidbody2D playerRB;

    GroundDetector groundDetectorScript;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        groundDetectorScript = GetComponent<GroundDetector>();

        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.Player.Jump.WasPressedThisFrame() && groundDetectorScript.isGrounded)
        {
            playerRB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
