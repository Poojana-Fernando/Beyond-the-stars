using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class LoadingManager : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI loadingText;
    public string sceneToLoad;

    private bool isReady = false;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    void Update()
    {
        bool isTouched =
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed) ||
            (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame);

        if (isReady && isTouched)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = Mathf.Lerp(slider.value, progress, Time.deltaTime * 5f);

            if (loadingText != null)
            {
                loadingText.text = (progress * 100f).ToString("F0") + "%";
            }

            if (operation.progress >= 0.9f)
            {
                isReady = true;

                slider.gameObject.SetActive(false);

                if (loadingText != null)
                {
                    loadingText.text = "Tap to Continue";
                }
            }

            yield return null;
        }
    }
}