using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject Player1WinText;
    public GameObject Player2WinText;
    public GameObject DrawText; 

    [Header("Other")]
    public AudioManager audioManager;

    public PlayerCrontroller Player1;
    public PlayerCrontroller Player2;

    public Rigidbody m_Rigidbody1;  //Player1
    public Rigidbody m_Rigidbody2;  //Player2
    public Rigidbody m_Rigidbody3;  //The Ball


    // linked in the inspector
    public Text Player1Score;
    public Text Player2Score;
 

    public void ScoreHasChanged ()
    {
        Player1Score.text = "Red : " + Player1.Score;
        Player2Score.text = "Blue : " + Player2.Score;

    }


    public void GameOver ()
    {
        bool player1Win = Player1.Score > Player2.Score;

        if (player1Win)
        {
            m_Rigidbody1.isKinematic = true;
            m_Rigidbody2.isKinematic = true;
            m_Rigidbody3.isKinematic = true;

            Time.timeScale = 0;
            audioManager.PlayPlayer1Wins();
            CanvasGame.SetActive(false);
            CanvasRestart.SetActive(true);
            Player1WinText.SetActive(true);
            Player2WinText.SetActive(false);
            DrawText.SetActive(false);

        }
        bool player2Win = Player1.Score < Player2.Score;
        if (player2Win)
        {

            m_Rigidbody1.isKinematic = true;
            m_Rigidbody2.isKinematic = true;
            m_Rigidbody3.isKinematic = true;

            Time.timeScale = 0;
            audioManager.PlayPlayer2Wins();
            CanvasGame.SetActive(false);
            CanvasRestart.SetActive(true);
            Player1WinText.SetActive(false);
            Player2WinText.SetActive(true);
            DrawText.SetActive(false);

        }
        bool draw = Player1.Score == Player2.Score;
        {
            if (draw)
            {
                m_Rigidbody1.isKinematic = true;
                m_Rigidbody2.isKinematic = true;
                m_Rigidbody3.isKinematic = true;

                Time.timeScale = 0;
                audioManager.DrawPlayers();
                CanvasGame.SetActive(false);
                CanvasRestart.SetActive(true);
                Player1WinText.SetActive(false);
                Player2WinText.SetActive(false);
                DrawText.SetActive(true);
            }
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
    }
   

  



}
