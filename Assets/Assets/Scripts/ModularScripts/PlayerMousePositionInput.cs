using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurretRotateTowardsPosition))]
public class PlayerMousePositionInput : MonoBehaviour
{
    private TurretRotateTowardsPosition turretRotate;
    private float mouseSensitivity = 1f;

    private void Awake()
    {
        turretRotate = GetComponent<TurretRotateTowardsPosition>();
    }

    private void FixedUpdate()
    {
        GatherAimingPosition();
    }

    private void GatherAimingPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition * mouseSensitivity);
        Plane plane = new Plane(Vector3.up, new Vector3(0, 0.5f, 0));
        float distance = 0;
        Vector3 position = new Vector3(0, 0, 0);
        // if the ray hits the plane...
        if (plane.Raycast(ray, out distance))
        {
            // get the hit point:
            position = ray.GetPoint(distance);
        }

        //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow, 1f);
        turretRotate.Rotate(position);
    }
}
