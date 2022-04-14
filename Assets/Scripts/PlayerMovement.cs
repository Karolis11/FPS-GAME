using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    SpawnManager spawnManager;

    private Vector3 velocity;
    
    private float speed = 8f;
    private float gravity = -9.81f * 3;
    private float groundDistance = 0.4f;
    private float jumpHeight = 1.6f;
    private float xBarier = 24.7f;

    private bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(transform.position.x > xBarier)
        {
            transform.position = new Vector3(xBarier, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Level1"))
        {
            spawnManager.SpawnEnemiesLevel1();
            xBarier = other.transform.position.x;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Level2"))
        {
            spawnManager.SpawnEnemiesLevel2();
            xBarier = other.transform.position.x;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Level3"))
        {
            spawnManager.SpawnEnemiesLevel3();
            xBarier = other.transform.position.x;
            Destroy(other.gameObject);
        }

    }


}
