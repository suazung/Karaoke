using UnityEngine;
using System.Collections;

public class InputPunch : MonoBehaviour {


	public string input;

	Vector3 oldPosition;


	public GameObject fadePanel;

	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		


		if(Input.GetKeyDown(KeyCode.J) )
		{
			transform.position += new Vector3 (0.0f , 0.0f , 2.0f);
		}
		if(Input.GetKeyUp(KeyCode.J) )
		{
			transform.localPosition = fadePanel.transform.localPosition;

			transform.localRotation = fadePanel.transform.localRotation;
		}

	}
}
