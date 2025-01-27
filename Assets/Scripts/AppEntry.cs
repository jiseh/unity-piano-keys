using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppEntry : MonoBehaviour
{
    [SerializeField] private float _splashDuration;

    private void Start()
    {
        Invoke(nameof(LaunchMenu), _splashDuration);
    }

    private void LaunchMenu()
    {
        SceneManager.LoadScene(1);
    }
}
