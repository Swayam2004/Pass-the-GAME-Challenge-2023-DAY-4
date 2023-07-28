using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BustedScreen : MonoBehaviour
{
    public float slideDuration = 1.5f;
    public Vector3 targetPosition;
    private Vector3 initialPosition;
    private bool isSliding = false;

    public Button restartButton;

    private void Start()
    {
        initialPosition = transform.localPosition;
        restartButton.onClick.AddListener(RestartLevel);
    }

    private void SlideOnScreenSmoothly()
    {
        if (!isSliding)
        {
            isSliding = true;
            StartCoroutine(SlidePanelSmoothly());
        }
    }

    private IEnumerator SlidePanelSmoothly()
    {
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;
    }

    public void RestartLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
