using UnityEngine;
using System.Collections;

public class ActiveOnEnable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		StartCoroutine (SetActiveAfterSecond() );
	}

	IEnumerator SetActiveAfterSecond()
	{
		yield return new WaitForSeconds (0.01f);
		gameObject.SetActive (false);
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
