using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Rigidbody rb;
    private ControladorDeDisparo controladorDeDisparo;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform posicionDeDisparo;
    [Range(1f, 100f)]
    [SerializeField] private float velocidadDeProyectil;

    private void Start()
    {
        controladorDeDisparo = FindObjectOfType<ControladorDeDisparo>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            controladorDeDisparo.DispararProyectil(posicionDeDisparo.position, velocidadDeProyectil);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = orientation.forward * zInput + orientation.right * xInput;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
