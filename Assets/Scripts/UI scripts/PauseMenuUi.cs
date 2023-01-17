using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUi : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button quitButton;

    private bool isPaused = false;
    void Start()
    {
        pauseMenuUI.SetActive(false);

        continueButton.onClick.AddListener(() =>
        {
            isPaused = false;
        });
        
        quitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.isEscapeButtonPressed())
        {
            Debug.Log("paused");
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
        }
    }
}
