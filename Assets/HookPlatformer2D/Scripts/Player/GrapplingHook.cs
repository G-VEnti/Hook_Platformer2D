using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    Rigidbody2D rb;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint2D;
    public LayerMask grappleLayer;
    public float circleRadius = 0.1f;
    public bool isGrappling;
    InputSystem_Actions inputs;
    Vector2 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint2D = GetComponent<DistanceJoint2D>();

        distanceJoint2D.enabled = false;
        lineRenderer.enabled = false;

        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapCircle(mousePos, circleRadius, grappleLayer))
            {
                isGrappling = true;
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, mousePos);
                distanceJoint2D.enabled = true;
                distanceJoint2D.connectedAnchor = mousePos;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isGrappling= false;
            distanceJoint2D.enabled = false;
            lineRenderer.enabled = false;
        }

        if(isGrappling)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, mousePos);
        }
    }
}
