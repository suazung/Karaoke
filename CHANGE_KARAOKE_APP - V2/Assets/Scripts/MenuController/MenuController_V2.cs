using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;
using UnityEngine.UI;




public class MenuController_V2 : MonoBehaviour {



	public VRStandardAssets.Menu.MenuButton leftButton;

	public VRStandardAssets.Menu.MenuButton rightButton;


	public VRStandardAssets.Menu.MenuButton[] music_menu_group;



	public GameObject MenuGroup;




	public int index;

	private int numberOfMusic = 0;



	IEnumerator SetPanelMiddleSlideLeft()
	{	

		float oldPositionX = MenuGroup.transform.localPosition.x;

		float positionX = MenuGroup.transform.localPosition.x;

		float i = positionX - 160;


		while( positionX >= i)
		{
			yield return null;
			MenuGroup.transform.localPosition = new Vector3 (positionX, MenuGroup.transform.localPosition.y, 0.0f);
			positionX = positionX - 10;
		}

		MenuGroup.transform.localPosition = new Vector3 (oldPositionX-160.0f , MenuGroup.transform.localPosition.y , 0.0f);

		StartCoroutine( SetCollider()  );

		StartCoroutine(SetLeftRightButton() );
	}


	IEnumerator SetPanelMiddleSlideRight()
	{	


		float oldPositionX = MenuGroup.transform.localPosition.x;

		float positionX = MenuGroup.transform.localPosition.x;

		float i = positionX + 160;

		while( positionX <= i)
		{
			yield return null;
			MenuGroup.transform.localPosition = new Vector3 (positionX , MenuGroup.transform.localPosition.y , 0.0f);
			positionX = positionX + 10;
		}
		MenuGroup.transform.localPosition = new Vector3 (oldPositionX+160.0f , MenuGroup.transform.localPosition.y , 0.0f);

		StartCoroutine( SetCollider() );
		StartCoroutine( SetLeftRightButton() );


	}


	IEnumerator SetCollider()
	{
		if(index == 0)
		{
			yield return null;

			for(int i = 0 ; i < music_menu_group.Length ; i++)
			{
				if (i < 1) {
					music_menu_group [i].gameObject.GetComponent<Collider> ().enabled = true;
				}
				else {
					music_menu_group [i].gameObject.GetComponent<Collider> ().enabled = false;
				}


			}


		}
		else if(index > 0 && index < music_menu_group.Length -1 )
		{
			yield return null;

			for(int i = 0 ; i < music_menu_group.Length ; i++)
			{
				if(i >= index && i < index + 1)
					music_menu_group [i].gameObject.GetComponent<Collider> ().enabled = true;
				else
					music_menu_group [i].gameObject.GetComponent<Collider> ().enabled = false;
			}


		}
		else if(index == music_menu_group.Length -1 )
		{
			yield return null;

			for(int i = 0 ; i < music_menu_group.Length ; i++)
			{
				if(i >= music_menu_group.Length -1 && i < index + 1)
					music_menu_group [i].gameObject.GetComponent<Collider> ().enabled = true;
				else
					music_menu_group [i].gameObject.GetComponent<Collider> ().enabled = false;
			}


		}
	}


	IEnumerator SetLeftRightButton ()
	{

		yield return null;

		if(index == 0)
		{

			leftButton .gameObject.GetComponent<Collider> ().enabled = false;
			leftButton .gameObject.GetComponent<Image> ().SetTransparency (0);
			rightButton.gameObject.GetComponent<Collider> ().enabled = true;
			rightButton.gameObject.GetComponent<Image> ().SetTransparency (255);
		}
		else if(index > 0 && index < music_menu_group.Length - 1 )
		{
			leftButton .gameObject.GetComponent<Collider> ().enabled = true;
			leftButton .gameObject.GetComponent<Image> ().SetTransparency (255);
			rightButton.gameObject.GetComponent<Collider> ().enabled = true;
			rightButton.gameObject.GetComponent<Image> ().SetTransparency (255);
		}
		else if(index == music_menu_group.Length -1 )
		{
			leftButton .gameObject.GetComponent<Collider> ().enabled = true;
			leftButton .gameObject.GetComponent<Image> ().SetTransparency (255);
			rightButton.gameObject.GetComponent<Collider> ().enabled = false;
			rightButton.gameObject.GetComponent<Image> ().SetTransparency (0);
		}

	}


	// Use this for initialization
	void Start () {





		for(int i = 0 ; i < music_menu_group.Length ; i++)
		{
			music_menu_group [i].transform.localPosition = new Vector3 ( i * 160.0f - 163 ,60.0f , 0.0f);
			music_menu_group [i].gameObject.SetActive (true);
		}





		leftButton.activateButtonDelegate = delegate(int _paramIndex) {

			index--;

			StartCoroutine( SetPanelMiddleSlideRight() );

		};


		rightButton.activateButtonDelegate = delegate(int _paramIndex) {

			index++;

			StartCoroutine( SetPanelMiddleSlideLeft() );

		};

		if (music_menu_group.Length <= 1) {
			leftButton.gameObject.GetComponent<Collider> ().enabled = false;
			leftButton.gameObject.GetComponent<Image> ().SetTransparency (0);
			rightButton.gameObject.GetComponent<Collider> ().enabled = false;
			rightButton.gameObject.GetComponent<Image> ().SetTransparency (0);
		}
		else {
			StartCoroutine( SetCollider()  );

			StartCoroutine(SetLeftRightButton() );

		}


	}



	// Update is called once per frame
	void Update () {


	}
}
