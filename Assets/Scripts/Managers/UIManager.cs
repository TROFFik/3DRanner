/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager singleton { get; private set; }

    [SerializeField] SaveManager saveManager;
    [SerializeField] GameObject uiMenu;
    [SerializeField] Text result;
    [SerializeField] Text bestScore;
    [SerializeField] Text yourScore;
    [SerializeField] Text inGameCoinsText;
    private GameManager gameManager;
    private AudioManager audioManager;
    private AnimatorManager animatorManager;
    private int coinsCount = 0;
    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        uiMenu.SetActive(false);
        animatorManager = AnimatorManager.singleton;
        audioManager = AudioManager.singleton;
        gameManager = GameManager.singleton;
        gameManager.gameOver += Dead;
    }

    public int GetCoins
    {
        set
        {
            coinsCount += value;
            inGameCoinsText.text =(": " + coinsCount);
        }
    }

    void Dead()
    {
        uiMenu.SetActive(true);
       (int CuurentCoins, bool IsWin) = saveManager.GetResult(coinsCount);

        if (IsWin)
        {
            animatorManager.Win = true;
            audioManager.WinAudio();
            result.text = ("You broke the record!!!");
            bestScore.text = ("Previous record: " + CuurentCoins);
            yourScore.text = ("Your result: " + coinsCount);
        }
        else
        {
            animatorManager.Win = false;
            audioManager.LoseAudio();
            result.text = ("Record not broken");
            bestScore.text = ("Record: " + CuurentCoins);
            yourScore.text = ("Your result: " + coinsCount);
        }
    }
}
