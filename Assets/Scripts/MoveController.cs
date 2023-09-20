using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] public int speed;
    [SerializeField] private int laneSpeed;

    private Rigidbody rb;
    private int currentLane = 1;
    private Vector3 verticalTargetPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void InputHandler()
    {
        if (SwipeController.swipeLeft)
        {
            ChangeLane(-3);
        }
        else if (SwipeController.swipeRight)
        {
            ChangeLane(3);
        }
    }

    public void Movebale()
    {
        Vector3 targetPosition = new Vector3(verticalTargetPosition.x, verticalTargetPosition.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSpeed * Time.deltaTime);
    }

    public void Move()
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void UnMove()
    {
        rb.velocity = Vector3.forward * 0;
    }

    private void ChangeLane(int direction)
    {
        int targetLane = currentLane + direction;

        if (targetLane < -4 || targetLane > 4)
            return;

        currentLane = targetLane;
        verticalTargetPosition = new Vector3((currentLane - 1), 0, 0);
    }
}
