using UnityEngine;

[RequireComponent(typeof(IShoot))]
public class PlayerShootInput : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        RetrieveFireInput();
    }

    private void RetrieveFireInput()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            GetComponent<IShoot>().Shoot();
        }
    }
}
