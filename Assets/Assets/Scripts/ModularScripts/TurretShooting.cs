using UnityEngine;

[RequireComponent(typeof(Ammo))]
public class TurretShooting : MonoBehaviour, IShoot
{
    public GameObject projSpawnPoint;
    public GameObject projectileType;

    public float fireRate = 0.01f;
    private float fireTime;

    private Ammo Ammo;

    private void Awake()
    {
        Ammo = GetComponent<Ammo>();
    }

    public void Shoot()
    {
        if (fireTime < Time.time)
        {
            //Shoot by instantiating a bullet
            if (CheckSpawnClearance() && Ammo.CheckAmmo())
            {
                Ammo.UseBullet();
                fireTime = Time.time + fireRate;
                GameObject currentInstantiated = Instantiate(projectileType, projSpawnPoint.transform.position, projSpawnPoint.transform.rotation);
            }
        }
    }

    //Returns true of spawn is clear
    public bool CheckSpawnClearance()
    {
        //Check if there are any obstructions at the barrell
        Collider[] hitColliders = Physics.OverlapSphere(projSpawnPoint.transform.position, 0.3f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].transform.CompareTag("Bullet") || hitColliders[i].transform.CompareTag("Wall"))
            {
                return false;
            }
        }
        return true;
    }
}
