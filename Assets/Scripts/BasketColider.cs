using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasketColider : MonoBehaviour
{
    private int _counter = 0;
    public TextMeshProUGUI ball;
    public static int ballValue = 0;

    public GameObject Bridge;
    public GameObject ScoreBoard;

    private void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        _checker();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _counter++;
            ballValue = _counter;
            Debug.Log("arttý"+" "+ _counter);
            ball.text = ballValue + " / " + "10";
        }
    }
    private void _checker()
    {
        if (_counter >=10)
        {
            gameObject.SetActive(false);
            Bridge.SetActive(true);
            GameManager.instance.gameStatusCache = gameStatus.PLAY;
        }
        else
        {
            Debug.Log("Baþarýsýz");
            GameManager.instance.gameStatusCache = gameStatus.FINISH;
        }
    }
}
