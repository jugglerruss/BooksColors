using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class BooksInstantiation : MonoBehaviour
{
    [SerializeField] private Color[] _colorsArray;
    [SerializeField] private Slider _booksCountSlider;
    [SerializeField] private Shelf _prefubShelf;
    [SerializeField] private Book _prefubBook;
    [SerializeField] private Camera _camera;
    private List<Shelf> _shelves;
    private List<Book> _books;
    private int _shelfsCount;
    private int _booksCountOnShelf;

    public List<Book> Books =>_books;
    public List<Shelf> Shelfs => _shelves;
    void Start()
    {
        _shelfsCount = _colorsArray.Length;
    }     
    public void GenerateBooks()
    {
        _books = new List<Book>();
        _booksCountOnShelf = (int)_booksCountSlider.value;
        var booksCount = _booksCountOnShelf * _shelfsCount;
        var booksIndexRnd = new int[booksCount];
        for (var i = 0; i < booksCount; i++)
        {
            var indexes = new List<int>();
            for(var j = 1; j <= _shelfsCount; j++)
            {
                if (booksIndexRnd.Where(b => b == j).Count() < _booksCountOnShelf)
                {
                    indexes.Add(j);
                }
            }
            var rnd = Random.Range(0, indexes.Count);
            booksIndexRnd[i] = indexes[rnd];
        }
        var booksIterator = 0;
        foreach (var shelf in _shelves)
        {
            for (var i = 0; i < _booksCountOnShelf; i++)
            {
                var posX = (_prefubBook.transform.localScale.x + 0.15f) * i - (_prefubBook.transform.localScale.x * _booksCountOnShelf) / 2;
                var posY = shelf.transform.position.y + _prefubBook.transform.localScale.y / 2 + shelf.transform.localScale.y;
                var book = Instantiate(_prefubBook, new Vector3(posX, posY, 0), new Quaternion());

                var color = _colorsArray[booksIndexRnd[booksIterator]-1];
                booksIterator++;

                book.GetComponent<ColorControl>().SetColor(color);
                book.transform.SetParent(shelf.transform);
                book.SetInstantiator(this);
                _books.Add(book); 
            }
        }
    }
    public void GenerateShelf()
    {
        _shelves = new List<Shelf>();
        var topPosY = _camera.orthographicSize;
        for(var i = 0; i < _shelfsCount; i++)
        {
            var shelv = Instantiate(_prefubShelf, new Vector3(0, topPosY - 25 * (i + 1), 0), new Quaternion());
            shelv.GetComponent<ColorControl>().SetColor(_colorsArray[i]);
            _shelves.Add(shelv);
        }            
    }

}
