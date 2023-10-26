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

    // Update is called once per frame
    void Update()
    {
        yellowText.text = yrbbCubes[0].ToString();
        redText.text = yrbbCubes[1].ToString();
        blueText.text = yrbbCubes[2].ToString();
        blackText.text = yrbbCubes[3].ToString();
    }

    public bool MinusCube(int cubeArrPos)
    {
        if (yrbbCubes[cubeArrPos] > 0)
        {
            yrbbCubes[cubeArrPos]--;
            wasCubeRemoved = true;
        }
        else
        {
            wasCubeRemoved = false;
        }

        return wasCubeRemoved;
    }

    public void NewResearch()
    {

    }
}
