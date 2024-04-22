using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private QuestManager questManager;
    private CharacterController characterController;
    private Vector3 velocity;
    private float gravity = -15f;
    private int apples = 0;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private Transform orientation;
    

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        characterController = GetComponentInChildren<CharacterController>();
    }

    private void Update()
    {
        Movement();
        QuestInputs();       
    }


    private void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = orientation.right * xInput + orientation.forward * zInput;

        characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void QuestInputs()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            questManager.CancelarMision(1);

        if (Input.GetKey(KeyCode.Alpha2))
            questManager.CancelarMision(2);

        if (Input.GetKey(KeyCode.Alpha3))
            questManager.CancelarMision(3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal") && questManager.quest2Active)
            questManager.CompletarMision(2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple") && questManager.quest1Active)
        {
            apples++;
            Destroy(collision.gameObject);
            if (apples == 5)
                questManager.CompletarMision(1);
        }

        if (collision.gameObject.CompareTag("Coin") && questManager.quest3Active)
        {
            Destroy(collision.gameObject);
            questManager.CompletarMision(3);
        }
    }
}
