using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {


	private float timer = 0.0f;

	public float timeToChange = 2.0f;

	float currentPositionX;

	float currentPositionZ;


	// Use this for initialization
	void Start () {

		currentPositionX = transform.position.x;

		currentPositionZ = transform.position.z;
		
		StartCoroutine ( DoRandom(timeToChange) );
	}


	IEnumerator DoRandom(float delay)
	{
		while(true)
		{
			yield return new WaitForSeconds (delay);

			StartCoroutine( RandomNewPosition () );

		}

	


	}

	IEnumerator RandomNewPosition()
	{
		

		float positionX = currentPositionX + Random.Range (currentPositionX - 15.0f, currentPositionX + 15.0f);

		float positionZ = currentPositionZ + Random.Range(currentPositionZ - 2.0f, currentPositionZ + 6.0f) ;

		yield return null;

		transform.position = Vector3.Lerp (transform.position ,new Vector3(positionX , -2.99f, positionZ ) , 5f );


	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
