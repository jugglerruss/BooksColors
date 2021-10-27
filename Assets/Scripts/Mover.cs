using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Mover : MonoBehaviour
{
    [SerializeField] float _moveDuration;
    private Sequence _sequenceTwins;
    void Start()
    {
        _sequenceTwins = DOTween.Sequence();
    }
    public void MoveToPosition(Vector3 position)
    {
        _sequenceTwins
            .Append(transform.DOMove(position, _moveDuration)
            .OnComplete(Stop)
            .SetEase(Ease.Linear));
    }
    private void Stop()
    {
        transform.GetComponent<Rigidbody2D>().simulated = true;
    }
}
