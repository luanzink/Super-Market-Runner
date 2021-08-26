using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //public AudioSource coinSound;
    private AudioClip coinSound;
    private CDeScene sceneController;

    private void Start()
    {
        //Referência à outros scripts.
        coinSound = this.gameObject.GetComponent<AudioSource>().clip;
        sceneController = GameObject.FindObjectOfType<CDeScene>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {   //Ativa som e adiciona dinheiro e score quando o player colidir com a moeda.
        if (other.tag == "Player" && sceneController.dis < 2000)
        {
            AudioSource.PlayClipAtPoint(coinSound, this.gameObject.transform.position);
            Destroy(gameObject);
            sceneController.money = sceneController.money + 0.50f;
            sceneController.CalculaDinheiro();
            sceneController.scoreExtra = sceneController.scoreExtra + 5;
        }

        if (other.tag == "Player" && sceneController.dis > 2000)
        {
            AudioSource.PlayClipAtPoint(coinSound, this.gameObject.transform.position);
            Destroy(gameObject);
            sceneController.money = sceneController.money + 0.5f;
            sceneController.CalculaDinheiro();
            sceneController.scoreExtra = sceneController.scoreExtra + 20;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
