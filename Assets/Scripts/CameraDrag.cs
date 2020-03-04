using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{

    public float speed = 100.0f;//easing speed
    public float maxSpeed = 20f;

    public float deadZone = 0.5f;
    [Tooltip("When the object hits this speed it will 0 out its velocity")]
    public float minVelocity = 0.025f;
    [Tooltip("How much velocity this objects looses per second")]
    public float slowPerSecond = 1;

    Vector3 currentPosition = Vector3.zero;
    Vector3 cameraPosition = Vector3.zero;
    float z = 0.0f;

    bool flag = false;
    Vector3 targetPosition;

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;

    private Vector3 velocity;
    private float zPos;

    private void Start()
    {
        zPos = Camera.main.transform.position.z;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LeftMouseDrag();
        }

        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        transform.position += velocity * speed;

        ReduceVelocity();
    }

    void LeftMouseDrag()
    {
        //Get length of drag
        Vector3 l = (dragEndPos - dragStartPos);
        float dragDistance = l.magnitude;
        

        // Get direction of movement. 
        Vector3 heading = transform.position - dragEndPos;
        heading.z = 0;

        if (heading.sqrMagnitude <= deadZone * deadZone)
            return;

        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        direction *= dragDistance;

        //if (Vector3.Dot(velocity, direction) < 0.5f)
        //    velocity = -velocity;

        velocity = direction * Time.deltaTime;
    }

    private void ReduceVelocity()
    {
        if (velocity == Vector3.zero)
            return;

        velocity += -velocity * (slowPerSecond * Time.deltaTime);

        if (velocity.sqrMagnitude <= minVelocity * minVelocity)
            velocity = Vector3.zero;
    }
}
