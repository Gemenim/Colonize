using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 directionX = new Vector3(1, 0, 0);
    private Vector3 directionZ = new Vector3(0, 0, 1);

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(directionX);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(-directionX);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Move(directionZ);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(-directionZ);
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position = transform.position + direction * _speed * Time.deltaTime;
    }
}
