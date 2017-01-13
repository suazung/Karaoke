using UnityEngine;
using System.Collections;

public class MiddleMenuController : MonoBehaviour {

	public ChapterDirector chapterDirector;


	public GameObject[] panelsMiddle ;
	[SerializeField] private int index = 1;


	public void ChangePanelByIndex(int _index)
	{
		index = _index;
		for(int i = 0 ; i < panelsMiddle.Length ; i++)
		{
			panelsMiddle [i].SetActive (i == index);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
