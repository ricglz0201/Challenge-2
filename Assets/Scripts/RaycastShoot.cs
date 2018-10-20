using UnityEngine;

public class RaycastShoot : MonoBehaviour {
  void Update() {
    if(Input.GetButtonDown("Fire1")) {
      RaycastIsShoot();
    }
  }

  private void RaycastIsShoot() {
    int layerMask = 1 << 8;
    layerMask = ~layerMask;
    RaycastHit hit;
    bool itHit = Physics.Raycast(transform.position,
                                    transform.TransformDirection(Vector3.forward), 
                                    out hit, 
                                    Mathf.Infinity, 
                                    layerMask);
    if (itHit) {
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
      Debug.Log("Did Hit");
    }
    else {
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
      Debug.Log("Did not Hit");
    }
  }
}