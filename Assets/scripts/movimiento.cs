using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControl : MonoBehaviour
{
    public float speed = 0.1f;
    public Vector3 currentPosition;
    private Vector3 lastFramePosition;


    void Start()
    {
        Application.targetFrameRate = 10;
    }


    public void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(movementX, movementY).normalized;

        currentPosition += new Vector3(movement.x, movement.y, 0f) * speed * Time.deltaTime;

        if (currentPosition.y < -8f)
        {
            currentPosition.y = -8f;
        }
        else if (currentPosition.y > 8f)
        {
            currentPosition.y = 8f;
        }

        if (currentPosition.x < -8f)
        {
            currentPosition.x = -8f;
        }
        else if (currentPosition.x > 8f)
        {
            currentPosition.x = 8f;
        }

        transform.position = currentPosition;

        float distanceThisFrame = Vector3.Distance(transform.position, lastFramePosition);

        if (distanceThisFrame > 0)
        {
            Debug.LogError($"distance this frame: {distanceThisFrame.ToString("f3")}");
        }

        lastFramePosition = transform.position;
    }
}
