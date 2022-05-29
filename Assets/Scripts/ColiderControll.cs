using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderControll : MonoBehaviour
{
    public GameObject Counter;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.gameStatusCache = gameStatus.CONTROLL;
            Counter.SetActive(true);
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
