using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] GameObject _bombPrefab;
    [SerializeField] GameObject _currentBomb;
    private RaycastHit _targetHit;

    private void Awake()
    {
        _currentBomb = GetComponentInChildren<BombController>().gameObject;
    }
    public void PrepeareBomb()
    {
        if (!GetComponentInChildren<BombController>())
            _currentBomb = Instantiate(_bombPrefab, transform);
    }
    public void Attack()
    {
        if (_currentBomb != null)
        {
            _currentBomb.GetComponent<BombController>().Attack();
        }
        PrepeareBomb();
    }
    private void Update()
    {
        if (Physics.Raycast(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward, out _targetHit))
        {
            if (_targetHit.collider != null)
                SetTarget(_targetHit.point);

            Debug.DrawLine(transform.position, _targetHit.point, Color.red, 2);
        }
    }
    public void SetTarget(Vector3 target)
    {
        _currentBomb.GetComponent<BombController>().SetTarget(target);
    }
}
