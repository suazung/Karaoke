using UnityEngine;
using System.Collections;

public class Configuration : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		UnityEngine.VR.VRSettings.renderScale = 1.5f;
	}
}
