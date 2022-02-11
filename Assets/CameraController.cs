using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float Speed = 50;
    void Update()
    {
        transform.Rotate(new Vector3(0, Speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0));
    }
}
