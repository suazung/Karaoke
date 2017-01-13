using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMiddleController : MonoBehaviour {


	public GameObject[] panelsMiddle ;
	[SerializeField] private int index = 0;
	private int lastIndex = 0;
	int count = 0;

	Vector3 transformObject;

	public void ChangePanelByIndex(int _index)
	{
		lastIndex = index;

		index = _index;
		for(int i = 0 ; i < panelsMiddle.Length ; i++)
		{
			if (i == index) {				
				panelsMiddle [i].SetActive (true);
			} else {
				panelsMiddle [i].SetActive (false);
			}
		}
	}


	// Use this for initialization
	void Start () {
		for(int i = 0 ; i < panelsMiddle.Length ; i++)
		{
			panelsMiddle [i].SetActive (i==index);
		}
		panelsMiddle [0].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
