using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contScena : MonoBehaviour
{
    public GameObject canvasT;
    public GameObject canvasM;

    void Start()
    {
        canvasT.SetActive(false);
    }
    public void tutorial()
    {
        canvasM.SetActive(false);
        canvasT.SetActive(true);
    }

    public void backmenu()
    {
        canvasM.SetActive(true);
        canvasT.SetActive(false);
    }
}
