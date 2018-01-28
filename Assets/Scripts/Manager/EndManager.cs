using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {

    [SerializeField]
    private string _menuSceneName;

    [System.Serializable]
    public struct UIElement
    {
        public CanvasGroup _canvasGroup;
        public float _alphaTarget;
        private float velocity;

        public void SetAlpha(float alpha)
        {
            _canvasGroup.alpha = alpha;
            _alphaTarget = alpha;
        }

        public void SmoothDampAlpha(float smoothTime)
        {
            SmoothDampAlpha(smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
        }

        public void SmoothDampAlpha(float smoothTime, float maxSpeed, float deltaTime)
        {
            _canvasGroup.alpha = Mathf.SmoothDamp(_canvasGroup.alpha, _alphaTarget, ref velocity, smoothTime, maxSpeed, deltaTime);
        }
    }

    [SerializeField]
    private UIElement _thanksForPlaying;

    [SerializeField]
    private UIElement _staff;

    [SerializeField]
    private UIElement _backToMenu;

	// Use this for initialization
	void Start () {
        SetAlphaToZero();
        StartCoroutine(EndSceneRoutine());
	}

    private void Update()
    {
        _thanksForPlaying.SmoothDampAlpha(1f);
        _staff.SmoothDampAlpha(1f);
        _backToMenu.SmoothDampAlpha(1f);
    }

    void SetAlphaToZero()
    {
        _thanksForPlaying.SetAlpha(0f);
        _staff.SetAlpha(0f);
        _backToMenu.SetAlpha(0f);
    }

    IEnumerator EndSceneRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        _thanksForPlaying._alphaTarget = 1f;

        yield return new WaitForSecondsRealtime(1f);
        _staff._alphaTarget = 1f;

        yield return new WaitForSecondsRealtime(1f);
        _backToMenu._alphaTarget = 1f;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(_menuSceneName);
    }

}
