using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivot : MonoBehaviour
{
    private Vector3 mouse;
    private Vector3 screenPoint;
    private Vector2 offset;

    private float angle;

    private float mouseSensitivity;

    void Awake()
    {
        SetMouseSensitivity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Gets the input mouse position
        Vector3 position = GatherAimingPosition();
        NewRotation(position);
    }

    public Vector3 ScreenPoint()
    {
        return screenPoint;
    }

    public void SetMouseSensitivity()
    {
        mouseSensitivity = GameManager.mouseSensitivity;
    }

    private Vector3 GatherAimingPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
        return position;
    }

    private void NewRotation(Vector3 positionToAimAt)
    {
        Vector3 playerToMouse = positionToAimAt - transform.position;
        playerToMouse.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        transform.rotation = newRotation;
    }

    private void OriginalRotation()
    {
        //Gets the input mouse position
        mouse = Input.mousePosition * mouseSensitivity;
        //Turns the position of the pivot to the poisiton on the screen
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        //Makes an angle between the difference in mouse and screen
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //Applies it to the transform.rotation
        transform.rotation = Quaternion.Euler(0, -angle, 0);
    }
}
