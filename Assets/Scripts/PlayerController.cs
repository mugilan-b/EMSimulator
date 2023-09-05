using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float spd;
    public float mouseSense;
    public GameObject cam;
    private Vector3 rotation;

    private Rigidbody rb;
    private Transform camtr;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        camtr = cam.GetComponent<Transform>();
        rotation = camtr.localEulerAngles;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * spd;
        if (Input.GetMouseButton(0))
        {
            //rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            rotation.z += 0f;
            camtr.localEulerAngles = rotation * mouseSense;
        }       
    }
}
