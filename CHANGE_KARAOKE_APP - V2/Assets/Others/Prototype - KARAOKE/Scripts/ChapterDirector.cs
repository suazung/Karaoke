using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChapterDirector : MonoBehaviour {

	public int beginChapterIndex = 0;
	public List<GameObject> objList = new List<GameObject>();
	public FadeImageCanvas fadeImageCanvas;

	private int index = -1;

	int previousLevel;

	public void ChangeChapter(int _index){
		index = _index;
		for(int i=0; i<objList.Count; ++i){
			objList[i].SetActive( i == index );
		}
	}

	public void BackToPreviousChapter(){
		if( index > 0 ){ ChangeChapter( index-1 ); }
	}

	public void BackToPreviousChapterWithFade(){
		fadeImageCanvas.Fade(delegate() {
			BackToPreviousChapter();				
		});
		StartCoroutine( CoDelay() );
	}

	// Use this for initialization
	void Awake ()
	{	
		
		ChangeChapter (beginChapterIndex);	
		//if( previousLevel == PlayerPrefs.GetInt( "9 - Test" ) )
	//	{
	//		ChangeChapter (1);                                          // Menu
	//	}

	}

	void Start()
	{
		
	}

	private bool isDelay = false;

	void Update(){
		if(isDelay){ return; }
		if(Input.GetKeyDown(KeyCode.Escape) && index == 2){
				BackToPreviousChapterWithFade ();
		}

	}

	private IEnumerator CoDelay(){ isDelay = true; yield return new WaitForSeconds(3f); isDelay = false; }
}
