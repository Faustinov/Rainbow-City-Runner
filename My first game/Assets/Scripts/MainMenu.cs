using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    public void TurnOn()
    {
        _canvas.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
