/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager uiManager;
    private AudioManager audioManager;
    private void Start()
    {
        uiManager = UIManager.singleton;
        audioManager = AudioManager.singleton;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            audioManager.CoinAudio();
            uiManager.GetCoins = 1;
            gameObject.SetActive(false);
        }
    }
}
