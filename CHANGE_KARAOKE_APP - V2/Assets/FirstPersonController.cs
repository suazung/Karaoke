using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float mouseSensitivity = 2.0f;

	public float upDownRenge = 60.0f;

	private float verticalRotation = 0.0f;

	float rotationLeftRight = 0.0f;


	public GameObject cameraObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {




		rotationLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity ;

		transform.Rotate (0,rotationLeftRight ,0);






		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity ;
	
		if(verticalRotation >= -upDownRenge && verticalRotation <= upDownRenge)
		{
			cameraObject.transform.localRotation = Quaternion.Euler (verticalRotation , 0 , 0);
		}
		// OR Use     verticalRotation = Mathf.Clamp (verticalRotation , -upDownRenge , upDownRenge);

	
	}
}
