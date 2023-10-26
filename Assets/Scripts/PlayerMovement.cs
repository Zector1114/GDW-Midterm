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
    int _actionsLeft = 4;
    int cubeArrayNum;

    // Start is called before the first frame update
    void Start()
    {
        _board.InitCityPositions();
        _board.InitResearch();
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
                    if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.transform.GetChild(0).transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.transform.GetChild(0).transform.position.y) <= 0.1f)
                    {
                        if (!_isMoving)
                        {
                            _turnStarted = false;
                            _actionsLeft = 4;
                            textField.text = "Actions Left: " + _actionsLeft.ToString();

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
                    else if (_actionsLeft > 0)
                    {
                        if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.transform.GetChild(1).transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.transform.GetChild(1).transform.position.y) <= 0.1f)
                        {
                            cubeArrayNum = 0;

                            RemoveCube();
                        }
                        else if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.transform.GetChild(2).transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.transform.GetChild(2).transform.position.y) <= 0.1f)
                        {
                            cubeArrayNum = 1;

                            RemoveCube();
                        }
                        else if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.transform.GetChild(3).transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.transform.GetChild(3).transform.position.y) <= 0.1f)
                        {
                            cubeArrayNum = 2;

                            RemoveCube();
                        }
                        else if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.transform.GetChild(4).transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.transform.GetChild(4).transform.position.y) <= 0.1f)
                        {
                            cubeArrayNum = 3;

                            RemoveCube();
                        }
                        else
                        {
                            for (int i = 0; i < _board.GetCities().Count; i++)
                            {
                                if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.GetCities()[i].transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.GetCities()[i].transform.position.y) <= 0.1f)
                                {
                                    for (int j = 0; j < _board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<ConnectedLocations>().GetLocations().Length; j++)
                                    {
                                        if (Mathf.Abs(hit.collider.gameObject.transform.position.x - _board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<ConnectedLocations>().GetLocations()[j].transform.position.x) <= 0.1f && Mathf.Abs(hit.collider.gameObject.transform.position.y - _board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<ConnectedLocations>().GetLocations()[j].transform.position.y) <= 0.1f)
                                        {
                                            _players[_currentPlayer].SetCurrentCity(i);
                                            _nextPos = hit.collider.gameObject.transform.position;
                                            _turnStarted = true;

                                            UpdateActions();
                                        }
                                    }
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

    void RemoveCube()
    {
        if (_board.GetCities()[_players[_currentPlayer].GetCurrentCity()].GetComponent<CityManager>().MinusCube(cubeArrayNum) == true)
        {
            UpdateActions();
        }
    }

    void UpdateActions()
    {
        _actionsLeft--;
        textField.text = "Actions Left: " + _actionsLeft.ToString();
    }
}
