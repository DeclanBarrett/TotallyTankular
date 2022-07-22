using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByDirection : MonoBehaviour
{
    public float movementSpeed = 1f;
    private const float MovementConst = 90f;

    private Vector3 currentPosition;
    public Vector3 CurrentPosition { get; }

    private Rigidbody currentRigidbody;
    public Rigidbody CurrentRigidbody { get; }


    private Quaternion targetRotation;
    private Vector3 movementForce;
    

    private void Awake()
    {
        //movementSpeed = GameManager.speed;
        currentRigidbody = this.GetComponent<Rigidbody>();
        currentRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    // Look at direction and slerp towards it
    private void RotateTowardsMovement(Vector3 movement)
    {
        currentRigidbody.transform.rotation = Quaternion.Slerp(currentRigidbody.rotation, Quaternion.LookRotation(movement, Vector3.up), 0.2f);
    }

    public bool Move(bool up, bool down, bool left, bool right)
    {
        //8 direction movement
        movementForce = new Vector3(0, 0, 0);
        if (right && up)
        {
            movementForce.x = movementSpeed * 0.75f;
            movementForce.z = movementSpeed * 0.75f;
        }
        else if (right && down)
        {
            movementForce.x = movementSpeed * 0.75f;
            movementForce.z = -movementSpeed * 0.75f;
        }
        else if (left && up)
        {
            movementForce.x = -movementSpeed * 0.75f;
            movementForce.z = movementSpeed * 0.75f;
        }
        else if (left && down)
        {
            movementForce.x = -movementSpeed * 0.75f;
            movementForce.z = -movementSpeed * 0.75f;
        }
        else if (right)
        {
            movementForce.x = movementSpeed;
        }
        else if (left)
        {
            movementForce.x = -movementSpeed;
        }
        else if (up)
        {
            movementForce.z = movementSpeed;
        }
        else if (down)
        {
            movementForce.z = -movementSpeed;
        } 

        currentRigidbody.AddForce(MovementConst * movementForce);
        this.RotateTowardsMovement(movementForce);

        return true;
    }

}
