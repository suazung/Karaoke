using UnityEngine;
using System.Collections;

public class ChangeActor : MonoBehaviour {

	public string prefix = "Actor";
	public GameObject []actors;
	public bool enableClick = false;
	private int index = 0;

	public TextMesh label;

	private void UpdateByIndex(){
		for(int i=0;i<actors.Length;++i){
			actors[i].SetActive( i == index );
		}
		if(label != null){ label.text = prefix+" : "+index; }
	}

	public void ChangeToIndex(int _index){
		index = _index;
		UpdateByIndex();
	}

	// Use this for initialization
	void Start () {
		UpdateByIndex();
	}
	
	// Update is called once per frame
	void Update () {
		if(!enableClick){ enabled = false; return; }

		if(Input.GetMouseButtonDown(0)){
			if(++index >= actors.Length){
				index = 0;
			}
			UpdateByIndex();
		}
	}
}
