using UnityEngine;
using System.Collections;

public class AnimMatAlpha : MonoBehaviour {

	public Material []matArr;
	private const float speed = 300;
	private const float minA = 77f/255f;
	private const float maxA = 195f/255f;

	
	// Update is called once per frame
	void Update () {
		float timeTick =   (Mathf.RoundToInt( Time.time * speed ) % 512);
		float alpha = Mathf.Lerp( minA, maxA, (timeTick > 255?512 - timeTick : timeTick)/255f ) ;
		matArr[0].SetColor("_TintColor", SetColorAlpha( matArr[0].GetColor("_TintColor"),alpha) );
	}

	private Color SetColorAlpha(Color col,float a){
		col.a = a;
		return col;
	}
}
