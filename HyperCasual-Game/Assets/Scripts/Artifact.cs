using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    public GameManager gameManager;
    public ParticleSystem collectEffect;
    public int minScore, maxScore;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 50);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            collectEffect.Play();
            Destroy(this.gameObject, 0.2f);

        }
    }
}
