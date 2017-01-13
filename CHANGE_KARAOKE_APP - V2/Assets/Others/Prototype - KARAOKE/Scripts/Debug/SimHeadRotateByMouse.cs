using UnityEngine;
using System.Collections;

public class SimHeadRotateByMouse : MonoBehaviour {

	public Transform tran;
	public float sensitivity = 1f;

	private float screenRatio = 1f;

	private Vector3 lastMousePos = Vector3.zero;
	private Vector3 eulerAngle = Vector3.zero;

	// Use this for initialization
	void Awake () {
		#if UNITY_EDITOR
			lastMousePos = Input.mousePosition;
			screenRatio = Screen.width/1024f;
		#else
			enabled = false;
			return;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		if(tran == null){ return; }

		if(Input.GetKeyDown("r")){ eulerAngle = Vector3.zero; } 

		Vector3 diff = (Input.mousePosition - lastMousePos)*sensitivity*Time.deltaTime*screenRatio;
		eulerAngle.x  -= diff.y;
		eulerAngle.y  += diff.x;
		tran.eulerAngles = eulerAngle;
		//tran.Rotate( -diff.y, diff.x, 0f );

		lastMousePos = Input.mousePosition;
	}
}
