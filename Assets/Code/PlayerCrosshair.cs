using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseToWorld.x, mouseToWorld.y, 0);
    }
}
