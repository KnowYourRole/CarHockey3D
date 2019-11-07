using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip BallCollision;
    public AudioClip Goal;
    public AudioClip Player1Wins;
    public AudioClip Player2Wins;
    public AudioClip Draw;
    public AudioClip BackgroundMusic; 

    private AudioSource audioSource;

    // this helps us to get the component and be able to add audio sources on different things such as when there is a goal
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // when the ball is touched by anything there will be audio playing
    public void PlayBallCollision ()
    {
        audioSource.PlayOneShot(BallCollision);
    }
    // when there is a goal only an audio will play
    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }
    // when player1 wins audio will be played 
    public void PlayPlayer1Wins()
    {
        audioSource.PlayOneShot(Player1Wins);
    }
    // when player2 wins audio will be played
    public void PlayPlayer2Wins()
    {
        audioSource.PlayOneShot(Player2Wins);
    }

    public void DrawPlayers()
    {
        audioSource.PlayOneShot(Draw);
    }
}
