using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minS = 12;
    private float maxS = 16;
    private float xRange = 4; 
    private float maxT = 10;
    private float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointV;

    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manger").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minS , maxS);
    }

    float RandomTorque()
    {
        return Random.Range(-maxT, maxT);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange , xRange),ySpawnPos);
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointV);
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
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
