using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverMenu;//facem o referinta pentru meniul nostru

    private void OnEnable()//functie de activare 
    {
        Monstru.OnPlayerDeath += ActivareGameOverMenu;//apelam enevimentul creat in codul pentru monstru si activam meniul
    }

    private void OnDisable()//functie de dezactivare
    {
        Monstru.OnPlayerDeath -= ActivareGameOverMenu;//apelam enevimentul creat in codul pentru monstru si dezactivam meniul
    }

    public void ActivareGameOverMenu()//functie prin care activam meniul de game over
    {
        gameOverMenu.SetActive(true);//il activam prin functia SetActive

    }

    public  void RestartGame()//functie pentru atunci cand dam restart jocului
    {
        SceneManager.LoadScene("Nivelul1");//reincarcam jocul la nivelu 1
    }

    public void MergiLaMainMenu()//functie pentru a trece la meniul principal
    {
        SceneManager.LoadScene("MainMenu");//facem trecerea spre meniul principal
    }
}
