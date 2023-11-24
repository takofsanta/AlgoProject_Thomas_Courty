using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Controller : MonoBehaviour

{
    public float spawnRate;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreTxt;
    private int score;
    public int scoreToAdd;

    public Image gameOver;
    public Button restartButton;
    public Button difficultyButton;
    public bool isGamePlaying;
    public UIManager _chosenDifficulty; 

    // Start is called before the first frame update
    void Start()
    {
        isGamePlaying = false;
        gameOver.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        isGamePlaying = true;
        spawnRate = _chosenDifficulty.difficultySelect;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        scoreTxt.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while (isGamePlaying == true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTxt.text = "Score : " + score;
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        isGamePlaying = false;
    }

    public void Restart()
    {
        gameOver.gameObject.SetActive(false);
        StartGame();
    }

    public void Difficulty()
    {
        _chosenDifficulty.difficulty.gameObject.SetActive(true);
        scoreTxt.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);

    }
}
