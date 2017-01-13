using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

using RenderHeads.Media.AVProVideo;




[System.Serializable]
public class MusicWordPrefabs {


	public GameObject musicPrefab;

	public float endWordTime = 0.0f;


}


public class ChangeMusicSequence : MonoBehaviour {


	public List<MusicWordPrefabs> musicPrefabs = new List<MusicWordPrefabs>(); 

	public int _index = 0;

	public MediaPlayer _media;


	public bool isUsingCorutine = false;




	// Use this for initialization
	void Start () {
		for (int i = 0; i < musicPrefabs.Count; i++) {
			musicPrefabs [i].musicPrefab = this.transform.GetChild (i).gameObject;
			musicPrefabs [i].musicPrefab.SetActive (false);
		}
	}






	void Update()
	{

			if(_index >= musicPrefabs.Count || (_media.Control.GetCurrentTimeMs () < musicPrefabs [0].endWordTime) )
			{
				_index = 0;


			}
			
			if(_media.Control.GetCurrentTimeMs () > musicPrefabs [musicPrefabs.Count - 1].endWordTime)
			{

				musicPrefabs [_index].musicPrefab.SetActive (false);
				_index = 0;

			}



			if (_media.Control.GetCurrentTimeMs () > musicPrefabs [_index].endWordTime)
			{

				musicPrefabs [_index].musicPrefab.SetActive (false);

				_index++;

			} 
			else if (_media.Control.GetCurrentTimeMs () <= musicPrefabs [_index].endWordTime) 
			{

				musicPrefabs [_index].musicPrefab.SetActive (true);

			}



	}
		


}

