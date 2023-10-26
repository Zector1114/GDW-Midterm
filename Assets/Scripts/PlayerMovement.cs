using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Inspector values
    [SerializeField] private List<Player> _players;
    public float _speed;

    [SerializeField] private Board _board = new Board();
    [SerializeField] private Text textField;

    // Positional values
    Vector2 _currentPos;
    Vector2 _nextPos;

    // Time variables
    float _totalTime;
    float _deltaT;

    // Game turn data
    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    // Current turn information
    int _currentPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _board.InitCityPositions();
    }

    void CheckWin()
    {
        // Check all 4 diseases are cured
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();

        if (!_gameIsOver)
        {
            _currentPos = _players[_currentPlayer].GetPosition();

            if (_currentPlayer == 0)
            {
                textField.color = Color.green;
            }
            else
            {
                textField.color = Color.magenta;
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    for (int i = 0; i < _board.GetCities().Count; i++)
                    {
                        if(Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.GetCities()[i].transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.GetCities()[i].transform.position.y) <= 0.1f)
                        {
                            for (int j = 0; j < _board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<ConnectedLocations>().GetLocations().Length; j++)
                            {
                                if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<ConnectedLocations>().GetLocations()[j].transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<ConnectedLocations>().GetLocations()[j].transform.position.y) <= 0.1f)
                                {
                                    _players[_currentPlayer].SetCurrentCity(i);
                                    _nextPos = hit.collider.gameObject.transform.position;
                                    _turnStarted = true;
                                }
                            }
                        }
                    }
                }
            }

            if (_turnStarted && !_isMoving)
            {
                MoveToCity();
            }

            if (_isMoving)
            {
                UpdatePosition();
            }

            if (!_isMoving)
            {
                textField.text = "Click a connected city to move to.";

                if (_turnStarted)
                {
                    _turnStarted = false;

                    if (_currentPlayer == 0)
                    {
                        _currentPlayer = 1;
                    }
                    else
                    {
                        _currentPlayer = 0;
                    }
                }
            }
        }
    }

    void UpdatePosition()
    {
        _deltaT += Time.deltaTime / _totalTime;

        if (_deltaT < 0f)
        {
            _totalTime = 0f;
        }

        if (_deltaT >= 1f || _nextPos == _currentPos)
        {
            _isMoving = false;
            _deltaT = 0f;
        }

        _players[_currentPlayer].SetPosition(Vector2.Lerp(_currentPos, _nextPos, _deltaT));
    }

    void MoveToCity()
    {
        _totalTime = (_nextPos - _currentPos / _speed).magnitude;
        _isMoving = true;
    }
}
