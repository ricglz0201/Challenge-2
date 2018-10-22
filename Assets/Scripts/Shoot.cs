using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public Rigidbody bullet;
	public int speed = 500;
	public float fireRate = 10;  // The number of bullets fired per second
	float lastfired;      // The value of Time.time at the last firing moment

	void Update () {
		if (Input.GetButton("Fire1")) {
	    	if (Time.time - lastfired > 1 / fireRate) {
	        	lastfired = Time.time;
	        	Rigidbody clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
	        	clone.velocity = transform.TransformDirection(new Vector3(0,0,speed));
	        	Destroy(clone.gameObject, 1);
	    	}
		}
	}
	
}
