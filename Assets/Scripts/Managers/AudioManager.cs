/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager singleton { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip clipJump;
    [SerializeField] private AudioClip clipCoin;
    [SerializeField] private AudioClip clipSit;
    [SerializeField] private AudioClip clipDead;
    [SerializeField] private AudioClip clipWin;
    [SerializeField] private AudioClip clipLose;

    private void Awake()
    {
        singleton = this;
    }
    public void JumpAudio()
    {
        audioSource.PlayOneShot(clipJump);
    }

    public void CoinAudio()
    {
        audioSource.PlayOneShot(clipCoin);
    }
    public void SitAudio()
    {
        audioSource.PlayOneShot(clipSit);
    }

    public void DeadAudio()
    {
        musicAudioSource.Stop();
        audioSource.PlayOneShot(clipDead);
    }

    public void WinAudio()
    {
        audioSource.PlayOneShot(clipWin);
    }

    public void LoseAudio()
    {
        audioSource.PlayOneShot(clipLose);
    }

}
