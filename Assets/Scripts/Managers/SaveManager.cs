/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int bestScore = 0;
    void SaveGame()
    {
        PlayerPrefs.SetInt("Score", bestScore);
        PlayerPrefs.Save();
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            bestScore = PlayerPrefs.GetInt("Score");
        }
        else bestScore = 0;
    }

    public (int, bool) GetResult(int CurrentScore)
    {
        LoadGame();
        if (bestScore < CurrentScore)
        {
            int PastRecord = bestScore;
            bestScore = CurrentScore;
            SaveGame();
            return (PastRecord, true);
        }
        else
        {
            return(bestScore, false);
        }
    }
}
