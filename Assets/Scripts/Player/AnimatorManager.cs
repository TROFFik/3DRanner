/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    public static AnimatorManager singleton { get; private set; }

    private Animator animator;

    private void Awake()
    {
        AnimatorManager.singleton = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool Run
    {
       set
       {
            animator.SetTrigger("Run");
       }
    }
    public bool Jump
    {
        set
        {
            animator.SetTrigger("Jump");
        }
    }
    public bool Sit
    {
        set
        {
            animator.SetTrigger("Sit");
        }
    }

    public bool Dead
    {
        set
        {
            animator.SetTrigger("Dead");
        }
    }

    public bool Win
    {
        set
        {
            animator.SetBool("Win", value);
        }
    }
}
