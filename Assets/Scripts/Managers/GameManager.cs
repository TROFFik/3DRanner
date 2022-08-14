/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{   
    public static GameManager singleton { get; private set; }
    public Action gameOver;
    private void Awake()
    {
        singleton = this;
    }

    public void GameOver()
    {
        gameOver?.Invoke();
    }
}
