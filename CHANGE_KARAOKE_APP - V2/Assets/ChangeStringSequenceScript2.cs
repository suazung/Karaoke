using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

using RenderHeads.Media.AVProVideo;




[System.Serializable]
public class StringForKaraoke2 {


	public string str;

	public List<CollectedChar> collectedChars  = new List<CollectedChar> ();

	public float startText = 0.0f;

	public float current = 0.0f;

	public float endText = 0.0f;

	public float localScaleX = 0.0015f;

	public float slowSpeed = 1;


}



[System.Serializable]
public class CollectedChar {


	public char chars;

	public float startChar = 0.0f;

	public float endChar = 0.0f;

	public CollectedChar(char c = ' ' , float start = 1.0f , float end = 10.0f)
	{
		chars = c;
		startChar = start;
		endChar = end;
	}


}




public class ChangeStringSequenceScript2 : MonoBehaviour {



	public Image backgroundBar;

	public Image musicBar;






	// Text music
	public Text text;






	//Reference
	public List<StringForKaraoke2> referenceString = new List<StringForKaraoke2>();

	// put reference to this
	public List<StringForKaraoke2> strs ;

	public int _index = 0;

	public MediaPlayer _media;

	string tempString = "" ;


	public Animator anim;


	public bool isUsingCorutine = false;




	// Use this for initialization
	void Start () {


		backgroundBar.rectTransform.localScale = new Vector3 (0,0,0);

		musicBar.rectTransform.localScale = new Vector3 (0.0f ,1.0f , 1.0f);


		text.text = "";


		strs = new List<StringForKaraoke2>(referenceString);






/*
		// LOOP ALL STRING
		for(int i = 0 ; i < strs.Count ; i++)
		{

			float delay = strs [i].endText - strs [i].startText;
			
			char[] temp = strs [i].str.ToCharArray ();

			float length = delay / temp.Length  ;

			float start = strs [i].startText;


			// LOOP  letter in a string
			for(int j = 0 ; j < temp.Length ; j++)
			{				

				CollectedChar cc = new CollectedChar(temp [j] , start  ,  start + length );

				start += length;

				strs [i].collectedChars.Add (cc);
			}

		}



*/



		StartCoroutine ( DoKaraoke() );


	}






	IEnumerator DoKaraoke()
	{


		while(true)
		{
			yield return null;




			if(_index >= strs.Count )
			{
				_index = 0;

			}


			if (_media.Control.GetCurrentTimeMs () < strs [0].startText) {

				_index = 0;

			} 
			else 
			{



				if (strs [_index].startText >= _media.Control.GetCurrentTimeMs () &&
					_media.Control.GetCurrentTimeMs () <= strs [_index].endText)
				{

					text.text = strs [_index].str;

					anim.Play("aaa");

					if( !isUsingCorutine)
					{
						float delay = ( strs [_index].endText - strs [_index].startText ) / 1000.0f ;

						if( delay != 0)
						{
							// Update MusucBar
							StartCoroutine(  UpdateMusicBar( delay)  );

						}


					}


				} 
				else if (  ( _media.Control.GetCurrentTimeMs () > strs [_index].endText ) //&&
					//( _media.Control.GetCurrentTimeMs () < strs [_index + 1].endText   ) 
				)
				{

					strs [_index].current = 0.0f;

					backgroundBar.rectTransform.localScale = new Vector3 (0,0,0);

					musicBar.rectTransform.localScale = new Vector3 (0.0f ,1.0f , 1.0f);


					_index++;

					isUsingCorutine = false;
				
				}			
				else
				{
					text.text = strs [_index].str;

					if( !isUsingCorutine)
					{
						// Update MusucBar
						StartCoroutine(  UpdateMusicBar( ( strs [_index].endText - strs [_index].startText ) / 1000.0f )  );


					}

				}

			}

		}



	}




	IEnumerator UpdateMusicBar(float delay)
	{

		isUsingCorutine = true;

		backgroundBar.rectTransform.localScale = new Vector3 ( strs [_index].localScaleX *100.0f ,0.02f,0.02f);

		float xxx = 0.0f;

		float original = 0.0f;


	
			// LOOP each char
			for(int x = 0 ; x < strs [_index].collectedChars.Count ; x++ )
			{
				// finding delay time in second
				float a = ( strs [_index].collectedChars[x].endChar -  strs [_index].collectedChars[x].startChar ) / 1000.0f;

				

				for(int y = 0 ; y <= 10 ; y++)
				{
					

					if( strs [_index].collectedChars.Count != 0)
					{
					strs [_index].current += (0.1f / strs [_index].collectedChars.Count * strs [_index].slowSpeed  )     ;     // ( 0.001f / a)  ;
					}

					if(strs [_index].current > 1.0f)
					{
						strs [_index].current = 1.0f;
					}

								
					
			        musicBar.rectTransform.localScale = new Vector3 (strs [_index].current  ,1.0f , 1.0f);


					yield return new WaitForSeconds ( a / 10.0f );


				}


		}

/*
		float x = delay / 100.0f;

		for(int i = 0 ; i < 100 ; i++)
		{

			yield return new WaitForSeconds ( x );

			strs [_index].current += 0.01f;

			musicBar.rectTransform.localScale = new Vector3 (strs [_index].current ,1.0f , 1.0f);
		}
*/




	}




}
