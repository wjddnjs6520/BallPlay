using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour
{
    public int TotalCoinCount;
    public int Stage;
    public TextMeshProUGUI TotalCoinText;
    public TextMeshProUGUI PlayerCoinText;
    public TextMeshProUGUI StageIntText;
    public Button PlayButton;
    public Button ExitButton;
    public Button ReplayButton;

    private void Awake()
    {
        TotalCoinText.text = TotalCoinCount.ToString();
        StageIntText.text = (Stage+1).ToString();
    }

    public void GetCoin(int Count)
    {
        PlayerCoinText.text = Count.ToString();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("BallPlayStage0");
    }

    public void GameExit()
    {
        Application.Quit();
    }
    public void GameReplay()
    {
        SceneManager.LoadScene("BallPlayStage0");
    }

}
