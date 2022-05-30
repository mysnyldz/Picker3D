using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class BasketColider : MonoBehaviour
{
    [SerializeField] private levelSOList levelSOList;
    public TextMeshProUGUI ball;
    public static int ballValue = 0;
    public GameObject Bridge;
    private int _level;
    private int _counter = 0;

    #region gate
    public GameObject RightGate;
    public GameObject LeftGate;
    public GameObject Red;
    public GameObject Green;
    public float GateAngle;
    #endregion

    public float WaitTime;


    private void OnEnable()
    {
        StartCoroutine(Wait());
        ball.text = (_counter + " / " + levelSOList.Levellist[_level].TargetScore).ToString();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(WaitTime);
        _checker();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _counter++;
            ballValue = _counter;
            ball.text = (_counter + " / " + levelSOList.Levellist[_level].TargetScore).ToString();
        }
    }
    private void _checker()
    {
        if (_counter >= levelSOList.Levellist[_level].TargetScore)
        {
            RightGate.transform.DORotate(new Vector3 (0f,0f,-(GateAngle)),0.5f);
            LeftGate.transform.DORotate(new Vector3 (0f,0f,(GateAngle)),0.5f);
            Red.SetActive(false);
            Green.SetActive(true);
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
