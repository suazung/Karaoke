using UnityEngine;
using System.Collections;

public class ChapterMenu : MonoBehaviour {

	public ChapterDirector chapterDirector;
	public VRStandardAssets.Menu.MenuButton []menuButtons;

	public FadeImageCanvas fadeImageCanvas;

	public ChangeActor bgChanger;
	//public ChangeActor actorChanger;

	// Use this for initialization
	void Start () {
		for(int i=0;i<menuButtons.Length;++i){
			menuButtons[i].activateButtonDelegate = delegate(int _paramIndex) {
				fadeImageCanvas.Fade(delegate() {					
					chapterDirector.ChangeChapter(1);
					bgChanger.ChangeToIndex( 	_paramIndex );
					//actorChanger.ChangeToIndex( _paramIndex );
				});
			};
		}
	}
}
