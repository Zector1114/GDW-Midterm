using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomMovement : MonoBehaviour
{
    public float zPos = 0;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = zPos;
        transform.position = mousePos;
    }
}
