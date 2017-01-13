using UnityEngine;
using System.Collections;

public class DoMovement : MonoBehaviour {

	public float speed = 10.0f;

	public float range = 1000.0f;       // meter

	public float f;
	// Use this for initialization
	void Start () {
		StartCoroutine ( Domove() );
	}

	IEnumerator Domove()
	{
		f = 0.0f;
		while (f < range) {
			yield return null;
			transform.position += new Vector3 (1.0f, 0.0f, 0.0f) * Time.deltaTime * speed;   //1*1*speed  = 1 * speed/second
			f += Time.deltaTime * speed ;
		}		  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
