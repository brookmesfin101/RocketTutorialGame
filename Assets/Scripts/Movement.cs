using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationSpeed = 100f;
    Rigidbody rb;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }           
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        } 
        else
        {
            _audioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationSpeed)
    {
        rb.freezeRotation = true; // freezing rotation so that we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        rb.freezeRotation = false;
    }
}
