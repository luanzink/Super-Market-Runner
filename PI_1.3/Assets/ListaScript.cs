using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListaScript : MonoBehaviour
{
    public GameObject[] obstacleArray = new GameObject[6];

    public float spawnWait;
    //float spawnMinWait = 0.5f;
    //float spawnMaxWait = 5.0f;
    public int startWait = 30;
    public bool stop;

    public GameObject playerPos;


    private void Start()
    {
        for (int i = 0; i < obstacleArray.Length; i++)
        {
            Instantiate(obstacleArray[i], new Vector3(0, 0, 0), Quaternion.identity);
            obstacleArray[i].SetActive(false);
        }

        StartCoroutine(Spawner());
    }

    private void Update()
    {
        spawnWait = 30f;
    }


    //Corrotina para fazer as moedas spawnarem com tempo.
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);


        while (!stop)
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

            Vector3 spawnPos = new Vector3(obstacleArray[Random.Range(0, obstacleArray.Length)].transform.position.x + random, 0, playerPos.transform.position.z + 500);

            Instantiate(obstacleArray[Random.Range(0, obstacleArray.Length)], spawnPos, Quaternion.identity).SetActive(true);

            yield return new WaitForSeconds(spawnWait);

        }
    }
}
