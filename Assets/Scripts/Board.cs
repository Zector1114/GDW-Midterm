using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    [SerializeField] private Transform _initialTransform;
    [SerializeField] private List<GameObject> _cities;

    Vector2[] _cityPositions = new Vector2[48];

    public List<GameObject> GetCities()
    {
        return _cities;
    }

    public Vector2[] GetCityPosition()
    {
        return _cityPositions;
    }

    public void InitCityPositions()
    {
        for (int i = 0; i < 47; i++)
        {
            _cityPositions[i] = new Vector2(_cities[i].transform.position.x, _cities[i].transform.position.y);
        }
    }

    public void InitResearch()
    {
        for (int i = 0; i <= 47; i++)
        {
            if (_cities[i].gameObject.name != _cities[12].gameObject.name)
            {
                _cities[i].GetComponent<CityManager>().research = false;
                _cities[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                _cities[i].GetComponent<CityManager>().research = true;
            }
        }
    }
}
