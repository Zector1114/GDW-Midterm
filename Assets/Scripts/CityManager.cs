using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    public bool research = false;
    [SerializeField] private int[] yrbbCubes = new int[4] { 0, 0, 0, 0 };
    [SerializeField] private Text yellowText;
    [SerializeField] private Text redText;
    [SerializeField] private Text blueText;
    [SerializeField] private Text blackText;

    bool wasCubeRemoved;

    private void Start()
    {
        yellowText.text = yrbbCubes[0].ToString();
        redText.text = yrbbCubes[1].ToString();
        blueText.text = yrbbCubes[2].ToString();
        blackText.text = yrbbCubes[3].ToString();
    }

    public bool MinusCube(int cubeArrPos, int playerNum)
    {
        if (playerNum == 1 && yrbbCubes[cubeArrPos] > 0)
        {
            yrbbCubes[cubeArrPos] = 0;
            wasCubeRemoved = true;
        }
        else if (yrbbCubes[cubeArrPos] > 0)
        {
            yrbbCubes[cubeArrPos]--;
            wasCubeRemoved = true;
        }
        else
        {
            wasCubeRemoved = false;
        }

        yellowText.text = yrbbCubes[0].ToString();
        redText.text = yrbbCubes[1].ToString();
        blueText.text = yrbbCubes[2].ToString();
        blackText.text = yrbbCubes[3].ToString();

        return wasCubeRemoved;
    }

    public void PlusCube(int cubeArrPos)
    {
        if (yrbbCubes[cubeArrPos] < 3)
        {
            yrbbCubes[cubeArrPos]++;
        }

        yellowText.text = yrbbCubes[0].ToString();
        redText.text = yrbbCubes[1].ToString();
        blueText.text = yrbbCubes[2].ToString();
        blackText.text = yrbbCubes[3].ToString();
    }

    public void NewResearch()
    {

    }
}
