using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour {


	public FadeImageCanvas fadeImageCanvas;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			fadeImageCanvas.Fade2 ( delegate {
				SceneManager.LoadScene ("scene5");
			});

		}
	}

}
