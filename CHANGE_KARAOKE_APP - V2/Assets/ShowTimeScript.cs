using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RenderHeads.Media.AVProVideo;

public class ShowTimeScript : MonoBehaviour {


	public Text showTime;

	public MediaPlayer _media;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		showTime.text = _media.Control.GetCurrentTimeMs ().ToString ();
	}
}
