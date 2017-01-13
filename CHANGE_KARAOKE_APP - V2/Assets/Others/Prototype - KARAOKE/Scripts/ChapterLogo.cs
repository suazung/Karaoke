using UnityEngine;
using System.Collections;

public class ChapterLogo : MonoBehaviour {

	public ChapterDirector chapterDirector;

	public GameObject []objs;
	public Material []mats;
	public Texture []textures;

	// Use this for initialization
	void OnEnable () {
		StopAllCoroutines();
		StartCoroutine( CoSeq() );
	}
	
	private IEnumerator CoSeq(){
		GameObject logoPanel = objs[0];
		GameObject announcementPanel = objs[1];

		logoPanel.SetActive(true);
		announcementPanel.SetActive(false);
		mats[0].SetColor("_TintColor",Color.white);

		yield return new WaitForSeconds(3f);

		logoPanel.SetActive(false);

		float duration = 2f;
		float timepos = 0f;
		while(timepos < duration){
			mats[0].SetColor("_TintColor", Color.Lerp( Color.white,Color.black, timepos/duration ) );
			timepos += Time.deltaTime;
			yield return null;
		}

		announcementPanel.SetActive(true);
		mats[0].SetColor("_TintColor",Color.black);
		mats[1].mainTexture = textures[0];

		yield return new WaitForSeconds(4f);

		mats[1].mainTexture = textures[1];

		yield return new WaitForSeconds(4f);

		announcementPanel.SetActive(false);
		timepos = 0f; duration = 3f;
		while(timepos < duration){
			mats[0].SetColor("_TintColor", Color.Lerp( Color.black,Color.white, timepos/duration ) );
			timepos += Time.deltaTime;
			yield return null;
		}
		mats[0].SetColor("_TintColor",Color.white);

		chapterDirector.ChangeChapter(1);
	}
}
