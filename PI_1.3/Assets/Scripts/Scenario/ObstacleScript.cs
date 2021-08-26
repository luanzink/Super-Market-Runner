using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleScript : MonoBehaviour
{
    public AudioClip collisionSound;
    //public CDeScene cd;
    public static bool bateu;

    private void Start()
    {
       // cd = GetComponent<CDeScene>();
        collisionSound = GetComponent<AudioSource>().clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            AudioSource.PlayClipAtPoint(collisionSound, this.gameObject.transform.position);
            //cd.GameOver();
            bateu = true;
            Time.timeScale = 0;
        }
    }



    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
