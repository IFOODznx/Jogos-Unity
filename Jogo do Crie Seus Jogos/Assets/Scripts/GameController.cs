using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalPontuacao;
    public static GameController instance;
    public TextMeshProUGUI textoPontuacao;
    public GameObject gameOver;
    
    void Start()
    {
        instance = this;
    }

    public void AtualizarPontuacao()
    {
        textoPontuacao.text = totalPontuacao.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void ReiniciarJogo(string Nivel_2)
    {
        SceneManager.LoadScene(Nivel_2);
    }
}
