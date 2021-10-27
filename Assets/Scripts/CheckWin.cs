using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private BooksInstantiation _booksInstantiator;
    [SerializeField] private int _stepsMax;
    [SerializeField] private Slider _booksCountSlider;
    [SerializeField] private TextMeshProUGUI _stepsMaxText;
    [SerializeField] private TextMeshProUGUI _stepsText;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _loseText;
    [SerializeField] private Image _panelGame;
    private int _steps;

    public bool GameOver { get; private set; }
    private void Start()
    {
    }
    public void ResetGame()
    {
        _steps = 0;
        _stepsMax = (int)_booksCountSlider.value * 2;
        _stepsMaxText.text = _stepsMax.ToString();
        _stepsText.text = _steps.ToString();
        GameOver = false;
    }
    public void Check()
    {
        _steps++;
        _stepsText.text = _steps.ToString();
        if (CheckForWin() || CheckForLose())
        {
            GameOver = true;
            _panelGame.color = new Color(256, 256, 256, 0.5f);
        }           
    }
    private bool CheckForLose()
    {
        if (_steps == _stepsMax)
        {
            _loseText.gameObject.SetActive(true);
            return true;
        }
        return false;
    }
    private bool CheckForWin()
    {
        var shelfs = _booksInstantiator.Shelfs;
        foreach(Shelf shelf in shelfs)
        {
            var books = shelf.transform.GetComponentsInChildren<ColorControl>();
            var shelfColor = shelf.GetComponent<ColorControl>().GetColor();
            if ( !books.All(b => b.GetColor() == shelfColor) )
                return false;

        }
        _winText.gameObject.SetActive(true);
        return true;
    }
}
