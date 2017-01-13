using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PngViewer : MonoBehaviour {

	public RawImage rawImage;

	public float timeDelay = 0.5f;

	public List<Texture2D> textures;

	public float frameRate = 30;








	IEnumerator Delay(float time)
	{
		yield return new WaitForSeconds (time);

	}

	// Use this for initialization
	void Start () {

		textures.Sort(
			delegate(Texture2D p1, Texture2D p2)
			{
				return string.Compare(p1.name,p2.name);
			}

		);

		StartCoroutine ( Play(timeDelay) );

	}



	IEnumerator Play(float time)
	{
		yield return new WaitForSeconds (time);


		while(true)
		{

			yield return null;

			int currentFrame = (int)(Time.time * frameRate) % textures.Count;
			if (currentFrame >= textures.Count)
				currentFrame = textures.Count - 1;

			rawImage.texture = textures[currentFrame];
		}


	}



	
	// Update is called once per frame
	void Update () {
/*	

		int currentFrame = (int)(Time.time * frameRate) % textures.Count;
		if (currentFrame >= textures.Count)
			currentFrame = textures.Count - 1;
		
		rawImage.texture = textures[currentFrame];

*/
	}
}
