using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BridgeMove : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOMoveY(1.0001f, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
