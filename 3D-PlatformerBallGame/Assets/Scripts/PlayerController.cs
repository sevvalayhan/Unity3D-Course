using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 20;
    float pushForce = 20f;
    public Vector3 respawnPoint;
    [SerializeField] GameManager gameManager;
    [SerializeField] SceneController sceneController;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = this.transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, rb.velocity.z);
        FallDetector();


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.transform.position = respawnPoint;
            gameManager.RespawnPlayer();
        }
    }
    private void FallDetector()
    {
        if (rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndTrigger"))
        {
            sceneController.LevelUp();
        }
    }

}
