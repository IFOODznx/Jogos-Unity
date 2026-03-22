using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void ComecarGamer(string Nivel_1)
    {
        SceneManager.LoadScene(Nivel_1);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
