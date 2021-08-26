using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager _platformManager;

    private void OnEnable()
    {
        _platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //yield return new WaitForSecondsRealtime(0.01f);
            _platformManager.RecyclePlatform(this.transform.parent.gameObject);
        }
    }
}
