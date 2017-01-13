using UnityEngine;
using System.Collections;

public class Shootiing : MonoBehaviour {

	public GameObject bulletPrefab;

	public float bulletImpulse = 100.0f;

	public GameObject CameraObject;

	public float delayBullet = 0.0f;


	// Use this for initialization
	void Start () {
	
	}

	IEnumerator DelayBulletAndFire( float delay)
	{	
		yield return new WaitForSeconds (delay);	
		GameObject theBullet = (GameObject)Instantiate (bulletPrefab , CameraObject.transform.position , CameraObject.transform.rotation);
		theBullet.GetComponent<Rigidbody> ().AddForce ( CameraObject.transform.forward * bulletImpulse , ForceMode.Impulse);


	}

	public void FireOut()
	{		
		StartCoroutine ( DelayBulletAndFire(delayBullet) );

	}

	public void NotFireOut()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
