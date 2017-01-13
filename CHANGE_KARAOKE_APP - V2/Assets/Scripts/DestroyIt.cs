using UnityEngine;
using System.Collections;

public class DestroyIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ( DesetroyThis() );
	}

	IEnumerator DesetroyThis()
	{
		yield return new WaitForSeconds (1.0f);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
