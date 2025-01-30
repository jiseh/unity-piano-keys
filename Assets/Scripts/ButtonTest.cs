using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _splash;

    private void Start()
    {
        _play.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
        _exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        _splash.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Splash");
        });
    }
}
