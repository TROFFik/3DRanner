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
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startPointerPotision = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    endPointerPotision = Input.GetTouch(0).position;
                    float DifferenceX = startPointerPotision.x - endPointerPotision.x;
                    float DifferenceY = startPointerPotision.y - endPointerPotision.y;
                    Debug.Log(DifferenceX);
                    if (DifferenceX < -100)
                    {
                        player.ChangeCuurentMovePointId(-DifferenceX);
                    }
                    else if(DifferenceX > 100)
                    {
                        player.ChangeCuurentMovePointId(-DifferenceX);
                    }
                    if (DifferenceY > 100)
                    {
                        player.Sit();
                    }
                    else if (DifferenceY < -100)
                    {
                        player.Jump();
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
