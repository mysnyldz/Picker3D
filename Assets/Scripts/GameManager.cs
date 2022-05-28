using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public gameStatus gameStatusCache;
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
