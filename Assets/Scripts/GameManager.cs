using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public gameStatus gameStatusCache;

    public event EventHandler MissionComp;
    public event EventHandler MissionFail;
    public event EventHandler Lvlup;
    public bool GameStarted = false;
    public event EventHandler GameStart;

    [SerializeField] private levelSOList levelList;

    private int _expCounter = 0;
    private int _level = 1;

    private void Start()
    {
        LoadSave();
    }

    public void LoadSave()
    {
        GameStart?.Invoke(this, EventArgs.Empty);
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameStatusCache = gameStatus.CONTROLL;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetExp() => _expCounter % 3;
    public int GetLvl() => _level;
    public int SetLvl(int newLvl) => _level = newLvl;

    public void ExpCounter()
    {
        MissionComp?.Invoke(this, EventArgs.Empty);
        gameStatusCache = gameStatus.PLAY;
        _expCounter++;
        LevelUp(_expCounter);
    }
    private void LevelUp(int _expCounter)
    {
        if (_expCounter != 0 && _expCounter % 3 == 0)
        {
            _level++;
            Lvlup?.Invoke(this, EventArgs.Empty);
        }
    }
    public void Failed()
    {
        gameStatusCache = gameStatus.FAIL;
        MissionFail?.Invoke(this, EventArgs.Empty);
    }
    public void RestartGame()
    {
        _expCounter = 0;
        SceneManager.LoadScene(0);
    }
}

public enum gameStatus
{
    NONE,
    PLAY,
    CONTROLL,
    FAIL,
    NEXT,
    FINISH
}
