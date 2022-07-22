using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnHit : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Bullet"){
			col.gameObject.SetActive(false);
			//Blow up
			//Die
		}
	}
}
