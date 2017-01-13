using UnityEngine;
using System.Collections;

public class DoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (  -Time.deltaTime * 15.0f , 0 ,0);
	}
}
