using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isGrounded;

    public float rayDistance;
    //public float circleCastRadius;

    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, rayDistance, mask);

        //RaycastHit2D circleHit = Physics2D.CircleCast(transform.position, circleCastRadius, Vector3.down, rayDistance, mask);

        if (rayHit.collider != null)
        {
            Debug.DrawRay(transform.position, Vector3.down * rayHit.distance, Color.green);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //if (circleHit.collider != null)
        //{
        //    Debug.DrawRay(transform.position, Vector3.down * circleHit.distance, Color.green);
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;

        //Gizmos.DrawWireSphere(transform.position, circleCastRadius);
        //Gizmos.DrawWireSphere(transform.position + Vector3.down * rayDistance, circleCastRadius);
    }
}
