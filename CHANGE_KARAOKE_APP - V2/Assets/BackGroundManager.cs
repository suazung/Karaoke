using UnityEngine;
using System.Collections;

public class BackGroundManager : MonoBehaviour {


	public Texture[] leftTexture;

	public Texture[] rightTexture;

	public Material materialLeft;

	public Material materialRight;

	public FadeImageCanvas fadeImageCanvas;

	public int index = 0;


	// Use this for initialization
	void Start () {


		fadeImageCanvas.Fade ( delegate {
			StartCoroutine (ChangeBG (index));
		});

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("a"))
			index++;
		
		if(index >= leftTexture.Length)
		{
			index = 0;
		}

		StartCoroutine (ChangeBG (index));
	}


	IEnumerator ChangeBG(int _index)
	{
		yield return new WaitForSeconds(1.0f);
		materialLeft.mainTexture = leftTexture [_index];
		materialRight.mainTexture = rightTexture [_index];
	}

}
