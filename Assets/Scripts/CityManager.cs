using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    public bool research = false;
    [SerializeField] private int yellowCube = 0;
    [SerializeField] private int redCube = 0;
    [SerializeField] private int blueCube = 0;
    [SerializeField] private int blackCube = 0;
    [SerializeField] private Text yellowText;
    [SerializeField] private Text redText;
    [SerializeField] private Text blueText;
    [SerializeField] private Text blackText;

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeCube(bool moreCube, int[] newCubes)
    {
        if (moreCube)
        {
            yellowCube += newCubes[0];
            redCube += newCubes[1];
            blueCube += newCubes[2];
            blackCube += newCubes[3];
        }
        else if (!moreCube)
        {
            yellowCube -= newCubes[0];
            redCube -= newCubes[1];
            blueCube -= newCubes[2];
            blackCube -= newCubes[3];
        }

        yellowText.text = yellowCube.ToString();
        redText.text = redCube.ToString();
        blueText.text = blueCube.ToString();
        blackText.text = blackCube.ToString();
    }

    void NewResearch()
    {

    }
}
