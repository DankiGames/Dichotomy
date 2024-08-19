using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWalkBack : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(-11, -5, 0);

    void Start()
    {
        transform.position = new Vector3(-3, 0, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position != endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }

    }
}
