using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CDeScene : MonoBehaviour
{
    //Referencias:
    public GameObject player;
    public Text distanceText;
    public Text scoreText;
    public Text moneyText;
    public Text montxt;
    public GameObject canvasPause;
    public GameObject hud;
    public GameObject canvasGO;

    //Variáveis:
   
    public int dis;
    public int scoreAtual;
    public int scorePassivo;
    public int scoreExtra;
    public float money = 0.00f;

    float speed;
    

    void Awake()
    {
        // inicia o jogo normal.

        canvasGO.SetActive(false);
        canvasPause.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1;

        dis = 0;
    }
    void Update()
    {
       
        // Congela o jogo e abre o menu de pause.
        if (Input.GetKeyDown(KeyCode.Escape))
             PauseGame();
       
        // Metodos:
        PegarDistancia();
        CalculaScore();       
        CalculaDinheiro();
        GameOver();
    }

    //Metodo para voltar a jogar.
    public void VoltarGame()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        hud.SetActive(true);
    }

    //Pausa o jogo pelo botão.
    public void PauseGame() {

        canvasPause.SetActive(true);
        Time.timeScale = 0;
        hud.SetActive(false);
        
    }

    void PegarDistancia()
    {
        dis = (int) player.transform.position.z;
        
        distanceText.text =" "+ dis;    
    }

    //Adiciona ou remove dinheiro.
    public void CalculaDinheiro()
    {
        moneyText.text = " " + money;
        montxt.text = " " + money;
    }
    

    // Adiciona ou remove score.
    public void CalculaScore()
    {
        scorePassivo =  dis / 10;
        scoreAtual = scorePassivo + scoreExtra;
        scoreText.text = " " + scoreAtual;
    }

    public void GameOver()
    {
        
        if (ObstacleScript.bateu == true)
        {
            hud.SetActive(false);
            Time.timeScale = 0;
            canvasGO.SetActive(true);
        }

    }

    public void pagarMoney()
    {
        if(money >= 50)
        {
            money = money - 50f;
            Time.timeScale = 1;
            ObstacleScript.bateu = false;
            canvasGO.SetActive(false);
            hud.SetActive(true);
        }
    }
}
