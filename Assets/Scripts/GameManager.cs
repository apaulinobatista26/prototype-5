using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List <GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleSreen;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public AudioSource audioSource;
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
      while (isGameActive)
      {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);
      }
    }


    public void UpdateScore(int scoreToAdd)
    {
      score += scoreToAdd;
      scoreText.text = "Score:" + score;
    }


    public void GameOver()
    {
      gameOverText.gameObject.SetActive(true);
      isGameActive = false;
      restartButton.gameObject.SetActive(true);
    }

    public void RastartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
      isGameActive = true;
       score = 0; 
       UpdateScore(0);
       UpdateLivesUI();
       titleSreen.gameObject.SetActive(false);
       StartCoroutine(SpawnTarget()); 
       spawnRate /= difficulty;
    }

    public void LoseLife()
    {
      lives--;
      UpdateLivesUI();
      if (lives <= 0)
      {
        GameOver();
      }
    }


    void UpdateLivesUI()
    {
      livesText.text = "Lives: " + lives;
    }
}


