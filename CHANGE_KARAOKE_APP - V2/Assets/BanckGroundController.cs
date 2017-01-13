using UnityEngine;
using System.Collections;

public class BanckGroundController : MonoBehaviour {

	public Texture2D[] texturesLeft;
	public Texture2D[] texturesRight;

	public Texture2D texturesLeftForMenuChepter;
	public Texture2D texturesRightForMenuChepter;

	public Material matLeftBackground;
	public Material matRightBackground;

	public int index = -1;

	public void SetBackgroundByIndex(int _index)
	{
		index = _index;
		StartCoroutine (ChangeBackground() );
	}

	IEnumerator ChangeBackground ()
	{
		yield return null;
		matLeftBackground.mainTexture = texturesLeft[  index];
		matRightBackground.mainTexture = texturesRight[ index];
	}



	public void SetMenuChepterBackground()
	{
		StartCoroutine (ChangeBackgroundMenuChepter() );
	}

	IEnumerator ChangeBackgroundMenuChepter ()
	{
		yield return null;
		matLeftBackground.mainTexture = texturesLeftForMenuChepter;
		matRightBackground.mainTexture = texturesRightForMenuChepter;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
