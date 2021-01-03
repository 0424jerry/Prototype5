using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameover;

    public bool isGameActive;
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpwanTarget());
        UpdateScore(0);
        isGameActive = true;
        //gameover.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpwanTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameover.gameObject.SetActive(true);
        //isGameActive = false; 
        restartButton.gameObject.SetActive(true);
    }
    

}
