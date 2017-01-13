using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

using RenderHeads.Media.AVProVideo;




[System.Serializable]
public class StringForKaraoke3 {


	public string str;

	public float endText = 0.0f;

	public float localScaleX = 0.0015f;

	public float slowSpeed = 1;


}








public class ChangeStringSequence3 : MonoBehaviour {



	public Animator anim;


	public Image backgroundBar;

	public Image musicBar;



	// Text music
	public Text text;




	// put reference to this
	public List<StringForKaraoke3> strings = new List<StringForKaraoke3>(); 

	public int _index = 0;

	public MediaPlayer _media;


	public bool isUsingCorutine = false;




	// Use this for initialization
	void Start () {


		musicBar.rectTransform.localScale = new Vector3 (0.0f ,1.0f , 1.0f);


		text.text = "";	 



		StartCoroutine ( DoKaraoke() );


	}






	IEnumerator DoKaraoke()
	{

		while(true)
		{
			yield return null;


			if(_index >= strings.Count || 
				(_media.Control.GetCurrentTimeMs () < strings [0].endText) )
			{
				_index = 0;

				anim.SetBool("go_to_bar_anime" ,true);

			}
			else if(_media.Control.GetCurrentTimeMs () > strings [strings.Count - 1].endText)
			{
				text.text = "";

				backgroundBar.rectTransform.localScale = new Vector3 ( 0.0f  ,0.02f,0.02f);

				_index = 0;

			}



			if (_media.Control.GetCurrentTimeMs () > strings [_index].endText)
			{
				
				anim.SetBool("go_to_index_"+_index.ToString() ,false);

				_index++;

			} 
			else if (_media.Control.GetCurrentTimeMs () <= strings [_index].endText) 
			{

				text.text = strings [_index].str;

				backgroundBar.rectTransform.localScale = new Vector3 ( strings [_index].localScaleX  ,0.02f,0.02f);

				StartCoroutine ( ShowAnimeBar() );

			}


		}

	}


		IEnumerator ShowAnimeBar()
		{

			yield return null;

			anim.SetBool("go_to_index_"+_index.ToString() ,true);
			
		}


}

