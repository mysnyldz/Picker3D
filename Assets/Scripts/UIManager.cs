using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject failed;
    [SerializeField] private GameObject lvl;
    [SerializeField] private TextMeshProUGUI lvlNow;
    [SerializeField] private TextMeshProUGUI lvlNext;
    [SerializeField] private List<Image> lvlImages;

    private void Start()
    {
        GameManager.instance.MissionFail += _instance_MissionFail;
        GameManager.instance.MissionComp += _instance_MissionComp;
        GameManager.instance.Lvlup += _instance_Lvlup;
        _updatelvlText();
    }

    private void Instance_GameStart(object sender, System.EventArgs e)
    {
        _updatelvlText();

    }
    private void _instance_Lvlup(object sender, System.EventArgs e)
    {
        Updatelvl();
    }
    private void _instance_MissionComp(object sender, System.EventArgs e)
    {
        ExpUp();
    }
    private void _instance_MissionFail(object sender, System.EventArgs e)
    {
        GameFailed();
    }
    private void _updatelvlText()
    {
        lvlNow.text = (GameManager.instance.GetLvl()).ToString();
        lvlNext.text = (GameManager.instance.GetLvl() + 1).ToString();
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        lvl.SetActive(true);
        GameManager.instance.gameStatusCache = gameStatus.PLAY;
    }

    public void GameFailed()
    {
        failed.SetActive(true);
    }
    public void ExpUp()
    {

        lvlImages[GameManager.instance.GetExp()].GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        _updatelvlText();

    }
    public void Updatelvl()
    {
        foreach (var changer in lvlImages)
        {
            changer.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }
        _updatelvlText();


    }
    public void ReTryBtn()
    {
        GameManager.instance.RestartGame();
    }
    private void OnDestroy()
    {
        GameManager.instance.MissionFail -= _instance_MissionFail;
        GameManager.instance.MissionComp -= _instance_MissionComp;
        GameManager.instance.Lvlup -= _instance_Lvlup;
    }

}
