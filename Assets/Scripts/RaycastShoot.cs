using UnityEngine;
using System.Collections;

public class RaycastShoot : MonoBehaviour {

	public int gunDamage = 1;
  public float fireRate = 0.25f;
  public float weaponRange = 500f;
  public float hitForce = 100f;
  public Camera fpsCam;
  public Transform ejection;
  public AudioSource gunAudio;
  public AudioSource colliderAudio;
  private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
  private LineRenderer laserLine;
  private float nextFire;

  void Start() {
    laserLine = GetComponent<LineRenderer>();
  }

  void Update() {
    if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      StartCoroutine (ShotEffect());
      Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
      RaycastHit hit;
      laserLine.SetPosition (0, ejection.position);
      if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange)){
        laserLine.SetPosition (1, hit.point);
        Collider collider = hit.collider;
        if(collider.tag == "Ball") {
          colliderAudio.Play();
          Destroy(collider.gameObject);
			    GeneralVars.score++;
        }
      } else {
        laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
      }
    }
  }

  private IEnumerator ShotEffect(){
    gunAudio.Play();
    laserLine.enabled = true;
    yield return shotDuration;
    laserLine.enabled = false;
  }
}