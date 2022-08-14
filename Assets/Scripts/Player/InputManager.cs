/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool stopGetInput;
    Player player;
    GameManager gameManager;
    private Vector2 startPointerPotision;
    private Vector2 endPointerPotision;
    void Start()
    {
        player = Player.singleton;
        gameManager = GameManager.singleton;
        gameManager.gameOver += Dead;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopGetInput)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.ChangeCuurentMovePointId(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.ChangeCuurentMovePointId(1);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player.Jump();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player.Sit();
            }


            if (Input.touchCount > 0)
            {
                Debug.Log(1);
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startPointerPotision = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    endPointerPotision = Input.GetTouch(0).position;
                    float DifferenceX = startPointerPotision.x - endPointerPotision.x;
                    float DifferenceY = startPointerPotision.y - endPointerPotision.y;
                    if (DifferenceX > 0.1)
                    {
                        player.ChangeCuurentMovePointId(DifferenceX);
                    }
                    if (DifferenceY > 0.1)
                    {
                        player.Jump();
                    }
                    else if (DifferenceY < -0.1)
                    {
                        player.Sit();
                    }
                }

            }
        }
    }

    void Dead()
    {
        stopGetInput = true;
    }
}
