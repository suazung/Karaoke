using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
	// This script is for loading scenes from the main menu.
	// Each 'button' will be a rendering showing the scene
	// that will be loaded and use the SelectionRadial.
	public class MenuButton : MonoBehaviour
	{
		public event Action<MenuButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

		public FadeImageCanvas fadeImageCanvas;
		                
		[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
		[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
		[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


		// SUA modified add
		public delegate void ActivateButtonDelegate(int paramIndex);
		public ActivateButtonDelegate activateButtonDelegate;
		[SerializeField] private int paramIndex = -1;
		[SerializeField] private string groupSide = "";



		public string SCENE_NAME = "";


		private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
		/*
		void Start(){
			fadeImageCanvas = GameObject.Find ("Fade Controller").GetComponent<FadeImageCanvas>();
			m_CameraFade = GameObject.Find ("Input Head Tran").GetComponent<VRCameraFade>();
			m_SelectionRadial = GameObject.Find ("Input Head Tran").GetComponent<SelectionRadial>();
		}*/


		private void OnEnable ()
		{
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
			m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;

			// Additional Modify
			m_InteractiveItem.OnOver += m_SelectionRadial.HandleDown;
			m_InteractiveItem.OnOut += m_SelectionRadial.HandleUp;
		}


		private void OnDisable ()
		{
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
			m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;

			// Additional Modify
			m_InteractiveItem.OnOver += m_SelectionRadial.HandleDown;
			m_InteractiveItem.OnOut += m_SelectionRadial.HandleUp;
		}


		private void HandleOver()
		{
			// When the user looks at the rendering of the scene, show the radial.
			m_SelectionRadial.Show();

			m_GazeOver = true;
		}


		private void HandleOut()
		{
			// When the user looks away from the rendering of the scene, hide the radial.
			m_SelectionRadial.Hide();

			m_GazeOver = false;
		}


		private void HandleSelectionComplete()
		{
			// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
			if(m_GazeOver)
				StartCoroutine (ActivateButton());
		}


		private IEnumerator ActivateButton()
		{
			// If the camera is already fading, ignore.
			if (m_CameraFade.IsFading)
				yield break;

			// If anything is subscribed to the OnButtonSelected event, call it.
			if (OnButtonSelected != null)
				OnButtonSelected(this);
	
			Debug.Log ("Type : " + groupSide + " , Param Index : " + paramIndex);
			if (groupSide == "LEFT") {
				if (activateButtonDelegate != null) {
					activateButtonDelegate (paramIndex);
				}
			} else if (groupSide == "MIDDLE") {   // MIDDLE


				if (SCENE_NAME != "") {


					fadeImageCanvas.Fade ( delegate {
						Debug.Log ("Scene name is " + SCENE_NAME);
						SceneManager.LoadScene (SCENE_NAME, LoadSceneMode.Single);
					});
					

				}
			} else {  // ControllMiddlePanel
				

				if(activateButtonDelegate != null)
				{
					activateButtonDelegate (paramIndex);

				}

			

			}


		}
	}
}