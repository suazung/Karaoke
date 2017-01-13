using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour {

	public float TimeMask = 0.1f;
	Image maskPic;

	void Start () {
		maskPic = this.transform.GetChild(0).GetComponent<Image>();
	}

	void Update () {

		maskPic.fillAmount -= TimeMask * Time.deltaTime;

	}
}
