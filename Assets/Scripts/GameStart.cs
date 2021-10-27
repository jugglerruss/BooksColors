using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BooksInstantiation))]
public class GameStart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _loseText;
    [SerializeField] private Image _panelGame;
    [SerializeField] private Image _panelMenu;
    private BooksInstantiation _booksInstantiation;
    private CheckWin _checkWin;
    void Start()
    {
        _booksInstantiation = GetComponent<BooksInstantiation>();
        _checkWin = FindObjectOfType<CheckWin>();
    }   
    public void StartGame()
    {
        _booksInstantiation.GenerateShelf();
        _booksInstantiation.GenerateBooks();
        _checkWin.ResetGame();
    }
    public void ReStartGame()
    {
        ClearGame();
        StartGame();
    }
    
    public void ToMenu()
    {
        ClearGame();
        _panelMenu.gameObject.SetActive(true);
        _panelGame.gameObject.SetActive(false);
    }

    private void ClearGame()
    {
        foreach (var shelf in FindObjectsOfType<Shelf>())
        {
            Destroy(shelf.gameObject);
        }
        _panelGame.color = new Color(256, 256, 256,0);
        _winText.gameObject.SetActive(false);
        _loseText.gameObject.SetActive(false);
    }   
}
