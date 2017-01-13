using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FadeImageCanvas : MonoBehaviour {

	public Image m_FadeImage;
	private bool m_IsFading;

	public Color startColor;
	public Color endColor;

	public delegate void OnFadeComplete();
	public OnFadeComplete onFadeComplete;

	// Use this for initialization
	void Start () {
		m_FadeImage.color = startColor;
	}

	void Update(){ if(Input.GetKeyDown("a")) Fade(); }

	public void Fade(OnFadeComplete _onFadeComplete = null){
		onFadeComplete = _onFadeComplete;
		StopAllCoroutines();
		StartCoroutine( BeginFade(startColor,endColor,1.0f) );
	}	

	public void Fade2(OnFadeComplete _onFadeComplete = null){
		onFadeComplete = _onFadeComplete;
		StopAllCoroutines();
		StartCoroutine( BeginFade2(startColor,endColor,1.0f) );
	}	





	private IEnumerator BeginFade(Color _startCol, Color _endCol, float duration)
        {
            // Fading is now happening.  This ensures it won't be interupted by non-coroutine calls.
            m_IsFading = true;

            // Execute this loop once per frame until the timer exceeds the duration.
            float timer = 0f;
            while (timer <= duration)
            {
                // Set the colour based on the normalised time.
                m_FadeImage.color = Color.Lerp(_startCol, _endCol, timer / duration);
                // Increment the timer by the time between frames and return next frame.
                timer += Time.deltaTime;
                yield return null;
            }

			// If anything is subscribed to OnFadeComplete call it.
			if (onFadeComplete != null)
				onFadeComplete();

			timer = 0f;
            while (timer <= duration)
            {
                // Set the colour based on the normalised time.
			m_FadeImage.color = Color.Lerp(_endCol, _startCol, timer / duration);

                // Increment the timer by the time between frames and return next frame.
                timer += Time.deltaTime;
                yield return null;
            }


            // Fading is finished so allow other fading calls again.
            m_IsFading = false;

        }



	private IEnumerator BeginFade2(Color _startCol, Color _endCol, float duration)
	{
		// Fading is now happening.  This ensures it won't be interupted by non-coroutine calls.
		m_IsFading = true;

		float timer = 0f;
		while (timer <= duration)
		{
			// Set the colour based on the normalised time.
			m_FadeImage.color = Color.Lerp(_startCol, _endCol, timer / 0.2f);
			// Increment the timer by the time between frames and return next frame.
			timer += Time.deltaTime;
			yield return null;
		}



		// If anything is subscribed to OnFadeComplete call it.
		if (onFadeComplete != null)
			onFadeComplete();

		timer = 0f;
		while (timer <= duration)
		{
			// Set the colour based on the normalised time.
			m_FadeImage.color = Color.Lerp(_endCol, _startCol, timer / duration);

			// Increment the timer by the time between frames and return next frame.
			timer += Time.deltaTime;
			yield return null;
		}


		// Fading is finished so allow other fading calls again.
		m_IsFading = false;

	}

}
