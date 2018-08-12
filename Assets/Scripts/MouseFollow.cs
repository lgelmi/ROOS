using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float maxSpeed = 0.5f;
    public float minimumDistance = 0;
    public float maximumDistance = 10;

    // Use this for initialization
    void Start()
    {
        follow();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow();
    }

    void follow()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float speed = maxSpeed * (distance - minimumDistance) / (maximumDistance - minimumDistance);
        print(distance);
        print(minimumDistance);
        print(speed);
        if (speed < 0)
            speed = 0;
        else if (speed > maxSpeed)
            speed = maxSpeed;
        Vector3 newPosition = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed);
        //Avoid movement on z axis
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
