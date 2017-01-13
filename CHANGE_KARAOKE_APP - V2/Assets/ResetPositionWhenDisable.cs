using UnityEngine;
using System.Collections;

public class ResetPositionWhenDisable : MonoBehaviour {


	private Vector3 StartPosition;

	void Awake()
	{
		StartPosition = transform.position;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable()
	{
		transform.position = StartPosition;
	}
}
