using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotateTowardsPosition : MonoBehaviour
{
    public float rotateSpeed;
    private Quaternion currentAngle;
    private Transform turret;

    private void Awake()
    {
        turret = GetComponent<Transform>();
    }

    public void Rotate(Vector3 positionToAimAt)
    {
        Vector3 turretToMouse = positionToAimAt - transform.position;
        turretToMouse.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(turretToMouse);
        turret.rotation = newRotation;
    }
}
