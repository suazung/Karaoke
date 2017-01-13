using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;


public class MenuManager : MonoBehaviour {

	public GameObject MenuGroup;
	public GameObject Mov;
	public int numMov;
	public MediaPlayer sendVdo;

	void Start () {
		for (int i = 0; i < numMov; i++) {
			GameObject Move = (GameObject)Instantiate(Mov);
			Move.name = "Movie "+ i;
			Move.transform.SetParent(MenuGroup.transform);
			Move.transform.position = MenuGroup.transform.position;
			Move.transform.GetChild (0).GetComponent<DisplayUGUI> ()._mediaPlayer = sendVdo;
		}

	}

	void Update () {
		
	}
}
