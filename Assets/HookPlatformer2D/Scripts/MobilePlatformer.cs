using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MobilePlatformer : MonoBehaviour
{
    public GameObject leftLimit;
    public GameObject rightLimit;
    public float leftLimitPos;
    public float rightLimitPos;
    public float speed;
    
    public Vector3 platformDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftLimitPos = leftLimit.transform.position.x;
        rightLimitPos = rightLimit.transform.position.x;
        platformDirection = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftLimitPos) platformDirection = Vector3.right;        
        else if (transform.position.x >= rightLimitPos)platformDirection = Vector3.left;

        transform.position += platformDirection * speed * Time.deltaTime;
    }
}
