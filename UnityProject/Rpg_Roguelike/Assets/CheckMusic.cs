using UnityEngine;
using System.Collections;

public class CheckMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip normal;
    public AudioClip boss;
    public AudioClip fineBattaglia;
    void Start ()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        if (stats.tipoIncontro == 0)
        {
            audioSource.clip = normal;
            audioSource.PlayDelayed(2);
        }
        else
        {
            audioSource.clip = boss;
            audioSource.PlayDelayed(2);
        }
    }

    public void EndBattleMusic()
    {
        audioSource.Stop();
        audioSource.clip = fineBattaglia;
        audioSource.Play();
    }
}
