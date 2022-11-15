using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    float _widthMultiplier = 0.0005f;
    float _heightMultiplier = 0.01f;

    [SerializeField] private Renderer _renderer;

    [SerializeField] private Transform _topSpine;
    [SerializeField] private Transform _bottomSpine;

    [SerializeField] private Transform _colliderTransform;

    [SerializeField] AudioSource _increaseSound;

    private void Start()
    {
        SetWidth(Progress.Instance.Width);
        SetHeight(Progress.Instance.Height);
    }

    void Update()
    {
        float offsetY = _height *  _heightMultiplier + 0.17f;
        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _colliderTransform.localScale = new Vector3(1, 1.84f + _height * _heightMultiplier, 1);


       // if (Input.GetKeyDown(KeyCode.W))
       // {
       //     AddWidth(20);
       // }      
       //if (Input.GetKeyDown(KeyCode.S))
       //{
       //     AddHeight(20);
       //}
    }

    public void AddWidth(int value)
    {
        _width += value;
        UpdateWidth();
        if (value > 0 )
        {
            _increaseSound.Play();
        }
    }
    public void AddHeight(int value)
    {
        _height += value;
        {
            _increaseSound.Play();
        }
    }

    public void SetWidth(int value)
    {
        _width += value;
        UpdateWidth();
    }
    public void SetHeight(int value)
    {
        _height += value;
    }


    public void HitBarrier()
    {
        if (_height > 0)
        {
            _height -= 50;
        }
        else if (_width > 0)
            {
                _width -= 50;
            UpdateWidth();
            }
        else
        {
            Die();
        }
    }

    void UpdateWidth()
    {
        _renderer.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    void Die()
    {
        FindObjectOfType<GameManager>().ShowFinishWindow();
        Destroy(gameObject);
    }
}
