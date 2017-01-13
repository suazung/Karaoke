using UnityEngine;
using System;
using System.Collections;

public class NavigateLookButton : MonoBehaviour {

	public VRStandardAssets.Utils.VRInteractiveItem interactiveItem;
	public VRStandardAssets.Menu.MenuButton menuButton;
	public AnimMatAlpha animMatAlpha;
	public Renderer _renderer;


	// Use this for initialization
	void Start () {
		_renderer.enabled = false;
		animMatAlpha.enabled = false;

		interactiveItem.OnOver += delegate() {
			_renderer.enabled = true;
			animMatAlpha.enabled = true;
		};

		interactiveItem.OnOut += delegate() {
			_renderer.enabled = false;
			animMatAlpha.enabled = false;
		};
	}
}
