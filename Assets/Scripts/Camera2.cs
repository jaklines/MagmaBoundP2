using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Transform playerT;
    public Transform cameraT;
    void Update()
    {
        if (playerT != null)
        {
            cameraT.position = new Vector3(Mathf.Clamp(playerT.position.x, -6.5f, 1.5f), Mathf.Clamp(playerT.position.y, -2.5f, 8.5f), -10);
        }
    }
}