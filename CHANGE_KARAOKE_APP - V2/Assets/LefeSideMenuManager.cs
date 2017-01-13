using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class LefeSideMenuManager : MonoBehaviour {

	public VRStandardAssets.Menu.MenuButton[] menuButtons;
	public GameObject[] MiddleMenuGroups; 
	private int currentIdex = 0;



	public int GetCurrentIndex()
	{
		return currentIdex;
	}


	public GameObject ReturnCurrentMenuPanelOnMiddleSide()
	{
		return MiddleMenuGroups[currentIdex] ;
	}


	public void SetMiddlePanelsByIndex(int _index)
	{
		currentIdex = _index;
		for(int i = 0 ; i < MiddleMenuGroups.Length ; i++)
		{
			MiddleMenuGroups [i].SetActive ( i == currentIdex);
		}
	}
	// Use this for initialization
	void Start () {


		StartCoroutine( SetTransparencyOrNot(currentIdex) ) ;

		SetMiddlePanelsByIndex(currentIdex);

		for(int i = 0 ; i < MiddleMenuGroups.Length ; i++)
		{
			menuButtons[i].activateButtonDelegate = delegate(int paramIndex)
			{
				if(paramIndex != currentIdex)
				{
					Panel_Middle_Position_Controller.SetPageZero();

					SetMiddlePanelsByIndex(paramIndex);

					StartCoroutine( SetTransparencyOrNot(paramIndex) ) ;

				}

			};
		}
	}

	private IEnumerator SetTransparencyOrNot(int index)
	{
		
		for(int i = 0 ; i < menuButtons.Length ; i++)
		{
			yield return null;
			if (i == index) {
				menuButtons [i].gameObject.GetComponent<Image> ().SetTransparency (0.65f);
				menuButtons [i].gameObject.GetComponent<Collider> ().enabled = false;
			} else {
				menuButtons [i].gameObject.GetComponent<Image> ().SetTransparency (1f);
				menuButtons [i].gameObject.GetComponent<Collider> ().enabled = true;
			}
		}
	}


	// Update is called once per frame
	void Update () {


	}
}


public static class Extensions
{
	public static void SetTransparency(this UnityEngine.UI.Image p_image, float p_transparency)
	{
		if (p_image != null)
		{
			UnityEngine.Color __alpha = p_image.color;
			__alpha.a = p_transparency;
			p_image.color = __alpha;
		}
	}


}

