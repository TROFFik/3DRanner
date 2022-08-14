/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player singleton { get; private set; }

    [SerializeField] private CapsuleCollider headCollider;
    [SerializeField] private int jumpForce;
    [SerializeField] private int speed;
    [SerializeField] private Transform[] movePoint;
    private int cuurentMovePointId;
    private AudioManager audioManager;
    private GameManager gameManager;
    private AnimatorManager animatorManager;
    private Rigidbody playerBody;
    private bool isLand = true;
    private bool isSit = false;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        animatorManager = AnimatorManager.singleton;
        audioManager = AudioManager.singleton;
        gameManager = GameManager.singleton;
        gameManager.gameOver += Dead;
        cuurentMovePointId = 1;
    }

    void Update()
    {
        if (transform.position != movePoint[cuurentMovePointId].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint[cuurentMovePointId].position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isLand = true;
    }

    public void Jump()
    {
        if (isLand)
        {
            playerBody.AddForce(Vector3.up * jumpForce);
            isLand = false;
            animatorManager.Jump = true;
            audioManager.JumpAudio();
        }
    }

    public void Sit()
    {
        if (!isSit)
        {
            isSit = true;
            animatorManager.Sit = true;
            headCollider.center = new Vector3(0, -10, 0);
            StartCoroutine(SitCorutine());
            audioManager.SitAudio();
        }
    }
    public void ChangeCuurentMovePointId(float Direction)
    {
        if (Direction > 0 && cuurentMovePointId != movePoint.Length-1)
        {
            cuurentMovePointId++;
        }
        else if (Direction < 0 && cuurentMovePointId != 0)
        {
            cuurentMovePointId--;
        }
    }

    public void Dead()
    {
        audioManager.DeadAudio();
        animatorManager.Dead= true;
    }
    private IEnumerator SitCorutine()
    {
        yield return new WaitForSeconds(1f);
        headCollider.center = new Vector3(0, 1, 0);
        isSit = false;
    }
}