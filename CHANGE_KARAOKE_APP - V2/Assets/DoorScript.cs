using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
	public class DoorScript : MonoBehaviour {

		public FadeImageCanvas fadeImageCanvas;


		public event Action<DoorScript> OnDoorSelected;                   // This event is triggered when the selection of the button has finished.

		[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.

		[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.

		[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.



		// ************************** SUA modified add **********************************
		public delegate void ActivateDoorDelegate(int paramIndex);

		public ActivateDoorDelegate activateDoorDelegate;

		[SerializeField] private int paramIndex = -1;

	



		private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


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
			m_SelectionRadial.Show();
			m_GazeOver = true;
		}


		private void HandleOut()
		{

		
			m_SelectionRadial.Hide();
			m_GazeOver = false;
		}


		private void HandleSelectionComplete()
		{
			// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
			if(m_GazeOver)
				StartCoroutine (ActivateWithDoor());
		}


		private IEnumerator ActivateWithDoor()
		{
			// If the camera is already fading, ignore.
			if (m_CameraFade.IsFading)
				yield break;

			// If anything is subscribed to the OnButtonSelected event, call it.
			if (OnDoorSelected != null)
				OnDoorSelected(this);

			Debug.Log ("Param Index : " + paramIndex);


			fadeImageCanvas.Fade2 ( delegate {
				SceneManager.LoadScene ("scene5");
			});


		}


	}

}