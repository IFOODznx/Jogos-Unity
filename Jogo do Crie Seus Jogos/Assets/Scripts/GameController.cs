using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalPontuacao;
    public static GameController instance;
    public TextMeshProUGUI textoPontuacao;
    
    void Start()
    {
        instance = this;
    }

    public void AtualizarPontuacao()
    {
        textoPontuacao.text = totalPontuacao.ToString();
    }

}
