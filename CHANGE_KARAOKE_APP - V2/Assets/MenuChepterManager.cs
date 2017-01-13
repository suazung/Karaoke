using UnityEngine;
using System.Collections;

public class MenuChepterManager : MonoBehaviour {

	public BanckGroundController backgroundController;
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable ()
	{
		backgroundController.SetMenuChepterBackground ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
