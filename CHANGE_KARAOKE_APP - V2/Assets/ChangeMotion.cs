using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeMotion : MonoBehaviour {



	public Texture2D[] frames;
	private List<Texture2D> sortList;
	bool isFading = false ;

	public Material mat;

	public GameObject actorQuad;

	int count;

	public float frameRate = 30;

	bool isDelayingInBeginning;




	void Start ()
	{
		
	
		sortList = new List<Texture2D>();
		for(int i=0;i<frames.Length;++i){
			sortList.Add( frames[i] );
		}
		sortList.Sort(
			delegate(Texture2D p1, Texture2D p2)
			{
				return string.Compare(p1.name,p2.name);
			}

		);

		//mat.mainTexture = sortList[0];
		//StartCoroutine ( HowMuchDelayInBeginning(5) );

		//isStarting = false;

	}

	void FirstDelay5Second(int frame)
	{
		mat.mainTexture = sortList[frame];
		StartCoroutine ( HowMuchDelayInBeginning(5) );
	}

	private IEnumerator HowMuchDelayInBeginning(float sec)
	{

		isDelayingInBeginning = true;
		yield return new WaitForSeconds(sec);
		isDelayingInBeginning = false;
	}




	void Update () 	{

		/*
		if (!isDelayingInBeginning) {
			
			int currentFrame = (int)(Time.time * frameRate) % sortList.Count;
			if (currentFrame >= sortList.Count)
				currentFrame = sortList.Count - 1;
			//		leftMat.mainTexture = rightMat.mainTexture = frames[currentFrame];

			Debug.Log ("currentFrame is " + currentFrame);
			mat.mainTexture = sortList [currentFrame];

		}
		*/

		if (!isDelayingInBeginning) {
			
			if (count >= sortList.Count) {
				count = 0;
				FirstDelay5Second (count);
			} else {
				if (count % 44 == 0) {
					//mat.mainTexture = sortList [currentFrame];
					FirstDelay5Second (count);
				}
				//Debug.Log ("currentFrame is " + count);
				//mat.mainTexture = sortList [count];
				//StartCoroutine ( HowMuchDelayInBeginning(0.0333f) );
				int currentFrame = (int)(Time.time * frameRate) % sortList.Count;
				if (currentFrame >= sortList.Count)
					currentFrame = sortList.Count - 1;
				//Debug.Log ("currentFrame is " + count);
				mat.mainTexture = sortList [count];
			}

			count++;

		}
	}
}
