using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Book : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private CheckWin _checkWin;
    private Mover _mover;
    private BooksInstantiation _booksInstantiator;
    private bool _isSelected;
    public bool IsSelected => _isSelected;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _mover = GetComponent<Mover>();
        _checkWin = FindObjectOfType<CheckWin>();
    }
    private void OnMouseDown()
    {
        if (_checkWin.GameOver)
            return;
        if (_isSelected)
        {
            FallDown();
            DeSelectBook();
        }
        else
        {
            PushUp();
            SelectBook();
        }
    }
    public void SetInstantiator(BooksInstantiation booksInstantiator)
    {
        _booksInstantiator = booksInstantiator;
    }
    public void MakeTransfer(Vector3 position,Transform parent)
    {
        MoveTo(position, parent);
        DeSelectBook();
        FallDown();
    }

    private void SelectBook()
    {
        var bookSelected = _booksInstantiator.Books.Where(b => b.IsSelected).FirstOrDefault();
        _isSelected = true;
        if (bookSelected != null)
        {
            var pos1 = bookSelected.transform.position;
            var shelf1 = bookSelected.transform.parent;
            var pos2 = transform.position;
            var shelf12 = transform.parent;
            MakeTransfer(pos1, shelf1);
            bookSelected.MakeTransfer(pos2, shelf12);
            _checkWin.Check();
        }
    }

    private void MoveTo(Vector3 position,Transform parent)
    {
        _rb.simulated = false;
        _mover.MoveToPosition(position);
        transform.parent = parent;
    }

    private void DeSelectBook()
    {
        _isSelected = false;
    }

    private void PushUp()
    {
        transform.position +=  new Vector3(0,1,0);
        _rb.isKinematic = true;
    }
    private void FallDown()
    {
        _rb.isKinematic = false;
    }
}
