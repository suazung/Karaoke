using UnityEngine;
using System.Collections;

public class DialogueBoxController : MonoBehaviour {

	public NavigateLookButton []buttons;

	public Transform boxTran;

	private Vector3 beginScale = Vector3.one;

	public delegate void ActionDelegate();

	// Use this for initialization
	void Start () {
		beginScale = boxTran.localScale;
		boxTran.localScale = Vector3.zero;
		boxTran.gameObject.SetActive(false);

		for(int i=0;i<buttons.Length;++i){
			int _i = i;
			buttons[i].menuButton.activateButtonDelegate += delegate(int _paramIndex) {

				StopAllCoroutines();
				StartCoroutine( CoScale(0f,.25f) );				

			};
		}			
	}

	void OnEnable(){
		StopAllCoroutines();
		StartCoroutine( CoShow() );
	}

	void OnDisable(){
		StopAllCoroutines();
		boxTran.localScale = Vector3.zero;
		boxTran.gameObject.SetActive(false);
	}

	private IEnumerator CoShow(){
		yield return new WaitForSeconds(3f);

		boxTran.gameObject.SetActive(true);
		StartCoroutine( CoScale(1f, .5f) );
	}

	private IEnumerator CoScale(float _scale,float duration = 1f,ActionDelegate _finishScaleDelegate = null){
		float timepos = 0f;

		Vector3 fromScale = boxTran.localScale;
		Vector3 toScale = beginScale*_scale;

		while(timepos < duration){

			boxTran.localScale = Vector3.Lerp(fromScale, toScale, timepos/duration);

			timepos += Time.deltaTime;
			yield return null;
		}

		boxTran.localScale = toScale;

		if(_finishScaleDelegate != null){ _finishScaleDelegate(); }
	}
}
