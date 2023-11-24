using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public Image difficulty;
    public Button easy;
    public Button medium;
    public Button hard;
    public float difficultySelect;
    public Controller _controller;

    public void EasyPressed()
    {
        difficultySelect = 1f;
        difficulty.gameObject.SetActive(false);
        _controller.StartGame();
    }
    public void MediumPressed()
    {
        difficultySelect = 0.5f;
        difficulty.gameObject.SetActive(false);
        _controller.StartGame();
    }
    public void HardPressed()
    {
        difficultySelect = 0.2f;
        difficulty.gameObject.SetActive(false);
        _controller.StartGame();
    }


}
