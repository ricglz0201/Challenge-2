using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public int speed = 100;
  public Rigidbody bullet;

  void Update() {
    if(Input.GetButtonDown("Fire1")) {
      Rigidbody clone = Instantiate(bullet,
                                    transform.position,
                                    transform.rotation)
                                    as Rigidbody;
      clone.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
      Destroy(clone.gameObject, 1);
    }
  }
	
}
