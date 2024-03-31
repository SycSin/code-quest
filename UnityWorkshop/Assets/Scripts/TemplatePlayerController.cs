using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplatePlayerController : MonoBehaviour
{
    public float AccelarationForward = 1f;
    public float BreakForce = 2f;
    public float RotateSpeed = 1f;
    public float SpeedFalloff = 1f;

    private float _currentSpeed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            _currentSpeed += AccelarationForward * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up, -RotateSpeed * Time.deltaTime);
        }

        float speedFalloff = SpeedFalloff;
        if (Input.GetKey("s"))
        {
            speedFalloff *= BreakForce;
        }

        _currentSpeed -= speedFalloff * Time.deltaTime;
        if (_currentSpeed < 0)
            _currentSpeed = 0f;
        
        var directionForward = transform.forward;
        transform.position += directionForward * _currentSpeed * Time.deltaTime;
    }
}
