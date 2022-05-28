using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayButton;
    // Start is called before the first frame update
    public void Play()
    {
        PlayButton.SetActive(false);

        GameManager.instance.gameStatusCache = gameStatus.PLAY;
    }
    
}
