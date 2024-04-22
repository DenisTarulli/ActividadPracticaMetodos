using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Score scoreClass;
    private int collectable1 = 10;
    private int collectable2 = 30;
    private int collectable3 = 70;
    private int collectable4 = 150;

    private void Start()
    {
        scoreClass = FindObjectOfType<Score>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");   
        float zInput = Input.GetAxisRaw("Vertical");   

        Vector3 moveDirection = new Vector3 (xInput, 0f, zInput);

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.tag.ToString();

        switch (name)
        {
            case "Collectable1":
                scoreClass.ActualizarPuntaje(collectable1);
                break;
            case "Collectable2":
                scoreClass.ActualizarPuntaje(collectable2);
                break;
            case "Collectable3":
                scoreClass.ActualizarPuntaje(collectable3);
                break;
            case "Collectable4":
                scoreClass.ActualizarPuntaje(collectable4);
                break;
        }

        if (!collision.gameObject.CompareTag("Ground"))
            Destroy(collision.gameObject);
    }
}
