using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10f;
    CurrentDirection cr;
    bool isGameOver = false;
    public GameManager gameManager;
    public ParticleSystem deadEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!isGameOver)
        {

            RayCastDetector();
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//Mobil platformda ekrana dokunduðumuzda çalýþacak olan kod
            /// if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeDirection();
                PlayerStop();
            }
            else
            {
                return;
            }
        }

    }
    void RayCastDetector()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            MovePlayer();

        }
        else
        {
            PlayerStop();
            this.gameObject.SetActive(false);
            isGameOver = true;
            gameManager.LevelEnd();
            Instantiate(deadEffect, this.transform.position, Quaternion.identity);
        }
    }
    private void ChangeDirection()
    {
        MovePlayer();
        if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
        else
        {
            cr = CurrentDirection.right;
        }
    }

    private enum CurrentDirection
    {
        right, left
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce(Vector3.forward.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
            rb.AddForce(Vector3.right.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);

        }

    }
    void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            this.gameObject.SetActive(false);
        }
    }
}
