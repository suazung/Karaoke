using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class Panel_Middle_Position_Controller : MonoBehaviour {


	public VRStandardAssets.Menu.MenuButton[] menuButtons;

	public GameObject[] MiddlePanelGroups; 

	public LefeSideMenuManager lefeSideManager;


	public static int page = 0;

	GameObject currentMenuPanel;


	public static void SetPageZero()
	{
		page = 0;

	}



	IEnumerator SetPanelMiddleSlideLeft()
	{	
		float oldPosition = currentMenuPanel.transform.localPosition.x;
		currentMenuPanel.transform.localPosition = new Vector3 ( oldPosition - 3403f ,-54.0f , 0.0f );    
		float positionX = currentMenuPanel.transform.localPosition.x;
		float i = positionX - 100;
		while( positionX >= i)
		{
			yield return null;
			currentMenuPanel.transform.localPosition = new Vector3 (positionX , -54.0f , 0.0f);
			positionX = positionX - 10;
		}
		currentMenuPanel.transform.localPosition = new Vector3 (oldPosition-3503.0f , -54.0f , 0.0f);

	}


	IEnumerator SetPanelMiddleSlideRight()
	{	
		float oldPosition = currentMenuPanel.transform.localPosition.x;
		currentMenuPanel.transform.localPosition = new Vector3 ( oldPosition + 3403f ,-54.0f , 0.0f );    
		float positionX = currentMenuPanel.transform.localPosition.x;
		float i = positionX + 100;
		while( positionX <= i)
		{
			yield return null;
			currentMenuPanel.transform.localPosition = new Vector3 (positionX , -54.0f , 0.0f);
			positionX = positionX + 10;
		}
		currentMenuPanel.transform.localPosition = new Vector3 (oldPosition+3503.0f , -54.0f , 0.0f);

	}


	void Start () {
		

		currentMenuPanel = lefeSideManager.ReturnCurrentMenuPanelOnMiddleSide ();

		for(int i = 0 ; i < menuButtons.Length ; i++)
		{
			menuButtons [i].activateButtonDelegate = delegate(int _paramIndex) {

				currentMenuPanel = lefeSideManager.ReturnCurrentMenuPanelOnMiddleSide ();


				if( _paramIndex == 0)                                     // LEFT ARROW
				{

					if(page > 0 && page <= 2 )
					{
						StartCoroutine( SetPanelMiddleSlideRight() );
						page--;
					}

				}
				else                                                      // RIGHT ARROW
				{
					if(page < 2 && page > -1)
					{
						StartCoroutine( SetPanelMiddleSlideLeft() );
						page++;

					}
				}			
			};
		}
	}


	void Update () {
	

		if (page == 0) {
			menuButtons [0].gameObject.GetComponent<Collider> ().enabled = false;
			menuButtons [0].gameObject.GetComponent<Image> ().SetTransparency (0);
			menuButtons [1].gameObject.GetComponent<Collider> ().enabled = true;
			menuButtons [1].gameObject.GetComponent<Image> ().SetTransparency (255);
		} else if (page > 0 && page < 2) {
			menuButtons [0].gameObject.GetComponent<Collider> ().enabled = true;
			menuButtons [0].gameObject.GetComponent<Image> ().SetTransparency (255);
			menuButtons [1].gameObject.GetComponent<Collider> ().enabled = true;
			menuButtons [1].gameObject.GetComponent<Image> ().SetTransparency (255);
		} else {
			menuButtons [0].gameObject.GetComponent<Collider> ().enabled = true;
			menuButtons [0].gameObject.GetComponent<Image> ().SetTransparency (255);
			menuButtons [1].gameObject.GetComponent<Collider> ().enabled = false;
			menuButtons [1].gameObject.GetComponent<Image> ().SetTransparency (0);
		}
	}
}


