using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using RenderHeads.Media.AVProVideo;

public class ChangeStringSequenceScript : MonoBehaviour {


	public float startDelay = 18.0f;

	public Text text;

	public Text textTime;

	public List<StringForKaraoke> strs = new List<StringForKaraoke>();

	public int count = -1;





	public Image backgroundBar;

	public Image musicBar;






	// Use this for initialization
	void Start () {
		StartCoroutine (ChangeString() );

	}



	IEnumerator ChangeString()
	{



		while(true)
		{					
			
			if(count >= strs.Count)
			{			

				count = -1;

			}

			if(count == -1)
			{

				backgroundBar.rectTransform.localScale = new Vector3 (0,0,0);

				musicBar.rectTransform.localScale = new Vector3 (0.0f ,1.0f , 1.0f);

				yield return new WaitForSeconds (startDelay);

				count++;
			}


		

			text.text = strs [count].str;

			backgroundBar.rectTransform.localScale = new Vector3 ( strs [count].localScaleX * 100.0f ,0.02f,0.02f);

			StartCoroutine ( UpdateMusicBar(strs [count].delay) );

			yield return new WaitForSeconds ( strs [count].delay );

			strs [count].current = 0.0f;

			count++;

		}


	}


	IEnumerator UpdateMusicBar(float delay)
	{
		float x = delay / 100.0f;

		for(int i = 0 ; i < 100 ; i++)
		{

			yield return new WaitForSeconds ( x );

			strs [count].current += 0.01f;

			musicBar.rectTransform.localScale = new Vector3 (strs [count].current ,1.0f , 1.0f);
		}




	}


	
	// Update is called once per frame
	void Update () {


	}
}



