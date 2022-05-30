using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    public gameStatus gameStatusCache;

    public event EventHandler MissionComp;
    public event EventHandler MissionFail;
    public event EventHandler Lvlup;
    public event EventHandler GameStart;

    public bool GameStarted = false;

    [SerializeField] private levelSOList levelList;

    private int _expCounter = 0;
    private int _level = 1;
    private int _score = 0;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            gameStatusCache = gameStatus.NONE;
        }
    }
}

public enum gameStatus
{
    NONE,
    PLAY,
    CONTROLL,
    NEXT,
    FINISH
}
