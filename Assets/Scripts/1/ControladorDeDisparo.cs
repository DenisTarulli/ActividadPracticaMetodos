using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeDisparo : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform playerOrientation;

    public void DispararProyectil(Vector3 posicion, float velocidadDelProyectil)
    {
        GameObject proyectil = Instantiate(bulletPrefab, posicion, Quaternion.identity);

        proyectil.GetComponent<Rigidbody>().velocity = playerOrientation.forward * velocidadDelProyectil;

        Destroy(proyectil, 4f);
    }
}
