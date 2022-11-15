using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum DeformationType
{
    Width,
    Height
}


public class GateAppearaence : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _topImage;
    [SerializeField] private Image _glassImage;
    [SerializeField] private Color _colorPositive;
    [SerializeField] private Color _colorNegative;

    [SerializeField] GameObject _expandLable;
    [SerializeField] GameObject _shrinkLable;
    [SerializeField] GameObject _upLable;
    [SerializeField] GameObject _downLable;

    public void UpdateVisual(DeformationType deformationType, int value)
    {
        string prefix = "";

        if (value > 0)
        {
            prefix = "+";
            SetColor(_colorPositive);
        } else if (value == 0) {
            SetColor(Color.grey);
        }
        else
        {
            SetColor(_colorNegative);
        }

        _text.text = prefix + value.ToString();

        _expandLable.SetActive(false);
        _shrinkLable.SetActive(false);
        _upLable.SetActive(false);
        _downLable.SetActive(false);

        if (deformationType == DeformationType.Width)
        {
            if (value > 0)
            {
                _expandLable.SetActive(true);
            }
            else
            {
                _shrinkLable.SetActive(true);
            }
        }
        else if (deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                _upLable.SetActive(true);
            }
            else
            {
                _downLable.SetActive(true);
            }
        }
    }

    private void SetColor(Color color)
    {
        _topImage.color = color;
        _glassImage.color = new Color(color.r, color.g, color.b, 0.4f);
    }
}
