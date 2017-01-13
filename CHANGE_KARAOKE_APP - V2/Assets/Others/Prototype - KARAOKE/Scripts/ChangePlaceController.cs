using UnityEngine;
using System.Collections;

public class ChangePlaceController : MonoBehaviour {

	public NavigateLookButton []buttons;
	public int []indexs;
	public FadeImageCanvas fadeImageCanvas;
	public ChapterDirector chapterDirector;
	public ChangeActor bg;
	public ChangeActor actor;
	// Use this for initialization
	void Start () {
		for(int i=0;i<buttons.Length;++i){
			int _i = i;
			buttons[i].menuButton.activateButtonDelegate += delegate(int _paramIndex) {

				chapterDirector.BackToPreviousChapterWithFade();

//				fadeImageCanvas.Fade(delegate {
//					actor.ChangeToIndex( indexs[_i] );
//					bg.ChangeToIndex( indexs[_i] );					
//				});
			};
		}
	}

}
