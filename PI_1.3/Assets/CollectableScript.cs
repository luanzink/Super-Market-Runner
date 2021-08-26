using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public GameObject gameOver;
    public CDeScene pScript;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(pScript.money >= 5f)
            {
                pScript.scoreExtra += 200;
                pScript.money -= 5f;
                Destroy(this.gameObject);
            }

            else if(pScript.money < 5f)
            {
                gameOver.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
