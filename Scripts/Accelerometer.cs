using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    [SerializeField] private float _sensetive = 20f;
    private Rigidbody _rig;
    
    // Start is called before the firs t frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            Vector3 acceleration = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
            _rig.AddForce(acceleration * _sensetive);
        }
    }
}
