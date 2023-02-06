using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScripts : MonoBehaviour
{
    public ScoreController scoreController;
    [SerializeField] float coinScore=10;
    private float rotate = 180f;

    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(0, 0, rotate * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            scoreController.AddScore(coinScore);

        }
    }
}
