using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Camera camera;
	[Range(1,1000)]
	public int BulletsPerSecond = 1;
	public GameObject bulletPrefab;
	private float fireTime;
    private float fireHoldoff;
	private string tagToShoot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fireTime = 1f/BulletsPerSecond;
		if(Input.GetButton("Fire1") && fireHoldoff <= 0f){
			if(Input.GetKey(KeyCode.A)){
				tagToShoot = "CubeBullet";
			}else{
				tagToShoot = "Bullet";
			}
			Debug.Log("Shooting " + tagToShoot);
			fireBullet();
			fireHoldoff = fireTime;
		}

		fireHoldoff -= Time.deltaTime;
	}

	void fireBullet(){
		Vector3 point = camera.ScreenToWorldPoint(Input.mousePosition);
		point.y = transform.position.y;
		Vector3 fireAngle = (point - transform.position);
		if(fireAngle.magnitude <= 0.001f){
			fireAngle = transform.forward;
		}
		
		GameObject newBullet = ObjectPool.GetPooledObject(tagToShoot);
		if(newBullet != null){
			newBullet.transform.position = transform.position + fireAngle.normalized;
			newBullet.transform.LookAt(transform.position + fireAngle);
			newBullet.SetActive(true);
		}
		
	}
}
