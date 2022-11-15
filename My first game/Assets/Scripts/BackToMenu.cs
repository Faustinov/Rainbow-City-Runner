using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    //[SerializeField] private PlayerMove _playerMove;

    public void BackTo()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelMenu()
    {
        _settings.SetActive(true);
        //_playerMove.enabled = false;
    }

    public void Cross()
    {
        _settings.SetActive(false);
        //_playerMove.enabled = true;
    }
}

