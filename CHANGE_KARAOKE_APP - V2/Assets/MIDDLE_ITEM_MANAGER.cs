using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class MIDDLE_ITEM_MANAGER : MonoBehaviour {

	public VRStandardAssets.Menu.MenuButton[] menuButtons;
	public BanckGroundController backGroundController;
	public FadeImageCanvas fadeImageCanvas;
	public ChapterDirector chapterDirector;

	// Use this for initialization
	void Start () {
		for(int i=0;i<menuButtons.Length;++i){
			menuButtons[i].activateButtonDelegate = delegate(int _paramIndex) {
				if(_paramIndex > -1){
					fadeImageCanvas.Fade(delegate() {	
						chapterDirector.ChangeChapter(1);
						Debug.Log("_paramIndex "+_paramIndex);
						backGroundController.SetBackgroundByIndex( 	_paramIndex );

					});
				}
			};

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
