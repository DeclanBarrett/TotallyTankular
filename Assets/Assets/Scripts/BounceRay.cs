using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

// Represents a set of bounced rays.
public class BounceRay
{
    // BounceRay result state.

    public List<Vector3> endPoints;
    public List<RaycastHit> contacts;
    public bool bounced;
    public Vector3 finalDirection;

    // Returns all contact points from a bouncing ray at the specified position and moving in the specified direction.
    public static BounceRay Cast(Vector3 position, Vector3 direction, float magnitude, int layerMask)
    {
        //Debug.Log("BounceRay");
        // Initialize the return data.
        BounceRay bounceRay = new BounceRay
        {
            contacts = new List<RaycastHit>(),
            endPoints = new List<Vector3>(),
            finalDirection = direction.normalized
        };

        // If there is magnitude left...
        if (magnitude > 0)
        {
            // Fire out initial vector.
            RaycastHit[] hit = Physics.RaycastAll(position, direction, magnitude, layerMask);

            // Calculate our bounce conditions.
            bool hitSucceeded = hit[0].collider != null && hit[1].distance > 0;
            bool magnitudeRemaining = hit[0].distance < magnitude;

            // Get the final position.
            Vector3 finalPosition = hitSucceeded ? hit[1].point : position + direction.normalized * magnitude;

            // Draw final position.
            //Debug.DrawLine(position, finalPosition, Color.green);

            // If the bounce conditions are met, add another bounce.
            if (hitSucceeded && magnitudeRemaining)
            {
                // Add the contact and hit point of the raycast to the BounceRay.
                bounceRay.contacts.Add(hit[0]);
                bounceRay.endPoints.Add(hit[0].point);

                // Reflect the hit.
                Vector3 reflection = Vector3.Reflect((hit[0].point - position).normalized, hit[0].normal);

                // Create the reflection vector
                Vector3 reflectionVector = reflection;

                // Bounce the ray.
                BounceRay bounce = Cast(
                    hit[0].point,
                    reflectionVector,
                    magnitude - hit[0].distance,
                    layerMask);

                // Include the bounce contacts and origins.
                bounceRay.contacts.AddRange(bounce.contacts);
                bounceRay.endPoints.AddRange(bounce.endPoints);

                // Set the final direction to what our BounceRay call returned.
                bounceRay.finalDirection = bounce.finalDirection;

                // We've bounced if we are adding more contact points and origins.
                bounceRay.bounced = true;
            }
            else
            {
                // Add the final position if there is no more magnitude left to cover.
                bounceRay.endPoints.Add(finalPosition);
                bounceRay.finalDirection = direction;
            }
        }

        // Return the current position & direction as final.
        return bounceRay;
    }
}
