using UnityEngine;

[RequireComponent(typeof(MovementByDirection))]
public class PlayerMovementByDirection : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        GatherMovementInput();
    }

    //Gather movement from Unity system and pipe into Move by direction
    private void GatherMovementInput()
    {
        bool up = Input.GetAxis("Vertical") > 0;
        bool down = Input.GetAxis("Vertical") < 0;
        bool left = Input.GetAxis("Horizontal") < 0;
        bool right = Input.GetAxis("Horizontal") > 0;

        if (up | down | left | right)
        {
            this.GetComponent<MovementByDirection>().Move(up, down, left, right);
        }
    }
}
