using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;


namespace VRStandardAssets.Menu
{

	public class EnamyScript : MonoBehaviour {

		public event Action<EnamyScript> OnEnamySelected;                   // This event is triggered when the selection of the button has finished.

		[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.

		[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.

		[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.




		// ************************** SUA modified add **********************************
		public delegate void ActivateEnemyDelegate(int paramIndex);

		public ActivateEnemyDelegate activateEnamyDelegate;

		[SerializeField] private int paramIndex = -1;
	
		public Shootiing shooting;



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
			shooting.FireOut ();

			m_GazeOver = true;
		}


		private void HandleOut()
		{
			
			shooting.NotFireOut();

			m_GazeOver = false;
		}


		private void HandleSelectionComplete()
		{
			// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
			if(m_GazeOver)
				StartCoroutine (ActivateWithEnamy());
		}


		private IEnumerator ActivateWithEnamy()
		{
			// If the camera is already fading, ignore.
			if (m_CameraFade.IsFading)
				yield break;

			// If anything is subscribed to the OnButtonSelected event, call it.
			if (OnEnamySelected != null)
				OnEnamySelected(this);

			Debug.Log ("Param Index : " + paramIndex);


		}
	}

}