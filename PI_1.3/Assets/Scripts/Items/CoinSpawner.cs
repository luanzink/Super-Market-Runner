using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;

    public float spawnWait;
    float spawnMinWait = 0.5f;
    float spawnMaxWait = 5.0f;
    public int startWait;
    public bool stop;

    public GameObject playerPos;
    private PlayerControl player;

    [Range(-5, 5)]int posValue;

    private void Start()
    {
        
        StartCoroutine(Spawner());
        player = GameObject.FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
    }


    //Corrotina para fazer as moedas spawnarem com tempo.
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);


        while (!stop)
        {
            if (player._speed <= 50)
            {
                int random = 0;
                int a;
                a = Random.Range(-5, 5);
                if (a > 2)
                    random = 5;
                if (a < -2)
                    random = -5;
                if (a > -2 && a < 2)
                    random = 0;

                Vector3 spawnPos = new Vector3(coin.transform.position.x + random, 0.25f, playerPos.transform.position.z + 70);
                Instantiate(coin, spawnPos, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait);
            }
            else {
                int random = 0;
                int a;
                a = Random.Range(-5, 5);
                if (a > 2)
                    random = 5;
                if (a < -2)
                    random = -5;
                if (a > -2 && a < 2)
                    random = 0;

                Vector3 spawnPos = new Vector3(coin.transform.position.x + random, 0.25f, playerPos.transform.position.z + 50);
                Instantiate(coin, spawnPos, Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }

        }
    }
}
