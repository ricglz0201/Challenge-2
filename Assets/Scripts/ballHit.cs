using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ballHit : MonoBehaviour {

	public GameObject gun;

	void OnCollisionEnter(Collision hit) {
		if (hit.gameObject.tag == "bullet") {
			gun.GetComponent<AudioSource>().Play();
			GeneralVars.score++;
			Destroy(this.gameObject);
		}
	}
}
