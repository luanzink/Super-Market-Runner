using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PulaScene : MonoBehaviour
{
    public string nomeDaSnene;

    //Metodo pega o nome de uma Scene e carrega ela.
    public void pularS()
    {
        SceneManager.LoadScene(nomeDaSnene);
        ObstacleScript.bateu = false;
    }

    //Esse metodo sai do jogo.
    public void SairDoJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
    
}
