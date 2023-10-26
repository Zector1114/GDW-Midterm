using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 _position;
    Transform _trans;

    int _currentCity = 12;

    bool _isPlayerTurn;

    private void Start()
    {
        _trans = GetComponent<Transform>();

        _position = _trans.position;
    }

    private void Update()
    {
        _trans.position = _position;
    }

    public Vector2 GetPosition()
    {
        return _position;
    }

    public void SetPosition(Vector2 pos)
    {
        _position = pos;
    }

    public bool GetIsPlayerTurn()
    {
        return _isPlayerTurn;
    }

    public void SetIsPlayerTurn(bool isTurn)
    {
        _isPlayerTurn = isTurn;
    }

    public int GetCurrentCity()
    {
        return _currentCity;
    }

    public void SetCurrentCity(int currentCity)
    {
        _currentCity = currentCity;
    }
}
