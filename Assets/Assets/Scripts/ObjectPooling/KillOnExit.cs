using UnityEngine;

public class KillOnExit : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if(other.tag == "Bullet"){
			other.gameObject.SetActive(false);
		}
	}
}
