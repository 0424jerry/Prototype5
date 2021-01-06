using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float MaxS = 16;

    private float MinS = 12;

    private float MaxT = 10;

    private float x = 4;

    private float y = -6;
    private GameManager gameManager;

    public int point;

    public ParticleSystem explosionP;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomT(),RandomT(),RandomT(),ForceMode.Impulse );
        transform.position = RandomS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.playon)
        { 
            Destroy(gameObject);
            Instantiate(explosionP,transform.position,explosionP.transform.rotation);
            gameManager.UpdateScore(point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MinS, MaxS);
    }

    float RandomT()
    {
        return Random.Range(-MaxT, MaxT);
    }

    Vector3 RandomS()
    {
        return new Vector3(Random.Range(-x,x),y);
    }
}
