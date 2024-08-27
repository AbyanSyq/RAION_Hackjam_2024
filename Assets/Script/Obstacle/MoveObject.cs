using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MultiDimentionBase, IReceiver
{
    public int amountToPess = 1;
    public int pressed = 0;
    [Space]
    public bool isMoving; // To check if the object is moving to the target
    public Vector3 moveTo; // Target position relative to the player’s start position
    public float moveSpeed = 2.0f; // Speed of movement
    [SerializeField] private Vector3 targetPosition; // Initial position when the scene starts
    [SerializeField] private Vector3 originalPosition; // Original position to return to

    void Start()
    {
        base.Start();
        originalPosition =  transform.position;// Set original position as initial position
        targetPosition = originalPosition + moveTo;
    }

    void Update()
    {
        
        if (isMoving)
        {
            transform.position = Vector3.Slerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move back to the original position
            transform.position = Vector3.Slerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void Receiver(bool press = true)
    {
        // isMoving = press; // Update the movement state based on the receiver's input
        if (press)
        {
            pressed++;
        }else{
            pressed--;
        }

        if (pressed >= amountToPess)
        {
            isMoving = true;
        }else{
            isMoving = false;
        }
    }
}
