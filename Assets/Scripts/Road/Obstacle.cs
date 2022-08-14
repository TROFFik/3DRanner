/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
      gameManager = GameManager.singleton;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            gameManager.GameOver();
        }
    }
}
