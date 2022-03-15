using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float Speed = 50;
    [SerializeField]
    Vector3 movement = Vector3.zero;
    void Update()
    {
        movement = new Vector3(0, Speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0);
        transform.Rotate(movement);
    }
}
