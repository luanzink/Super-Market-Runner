using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(-2, 2)] public float value;
    private CharacterController _controller;
    public Animator cadeira;
    public AudioClip puloSound;


    [SerializeField]
    public float _speed = 10.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    private float _yVelocity = 0.0f;

    private CDeScene sceneController;


    void Start()
    {
        cadeira = GetComponent<Animator>();
       _controller = GetComponent<CharacterController>();
        sceneController = GameObject.FindObjectOfType<CDeScene>();
        puloSound = GetComponent<AudioSource>().clip;

    }

    void Update()
    {
        //Direção:
        Vector3 direction = new Vector3(0, 0, 1);
        //Velocidade:
        Vector3 velocity = direction * _speed;

        if (_speed <= 70.0f)
            _speed += 0.5f * Time.deltaTime;

        //Pulo:
        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            { 
                AudioSource.PlayClipAtPoint(puloSound, this.gameObject.transform.position);
                _yVelocity = _jumpHeight;
                cadeira.SetBool("pulo", true);
                
            }
        }
        else
        {
            _yVelocity -= _gravity;
            cadeira.SetBool("pulo", false);
        }

        velocity.y = _yVelocity;

        //Mover:
        _controller.Move(velocity * Time.deltaTime);

        //Mudar posição:
        transform.position = new Vector3(value, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Right"))
        {
            if (value == 5)
                return;
            value += 5;
            cadeira.SetBool("dir", true);
        }
        else
            cadeira.SetBool("dir", false);

        if (Input.GetButtonDown("Left"))
        {
            if (value == -5)
                return;
            value -= 5;
            
                cadeira.SetBool("esq", true);
        }
        else
            cadeira.SetBool("esq", false);
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Coin")
        {
            sceneController.money = sceneController.money + 0.50f;
            sceneController.CalculaDinheiro();
            sceneController.scoreExtra = sceneController.scoreExtra + 5;
            //sceneController.MostraScore();
        }
    }*/
}
