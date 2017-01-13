using UnityEngine;
using System.Collections;

public class MimicPositionAndRotation : MonoBehaviour {

	public Transform originalTran;
	public Transform mimicTran;
	
	// Update is called once per frame
	void FixedUpdate () {
		mimicTran.position = originalTran.position;
		mimicTran.rotation = originalTran.rotation;
	}
}
