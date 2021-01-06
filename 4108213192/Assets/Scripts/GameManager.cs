using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    private int score;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameoverText;
    public Button restart;
    public GameObject title;

    public bool playon;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (playon)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void UpdateScore(int n)
    {
        score += n;
        scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        restart.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        playon = false;
    }

    public void RestartG()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startgame(int level)
    {
        playon = true;
        score = 0;
        spawnRate /= level;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        title.gameObject.SetActive(false);
    }
}
