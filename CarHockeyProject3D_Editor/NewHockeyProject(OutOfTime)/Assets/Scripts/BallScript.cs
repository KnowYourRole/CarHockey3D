using System.Collections;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;

    public AudioManager audioManager;
    
    public UiManager UiManager;
    public GameObject RedCarFastP1; //new
    public GameObject BlueCarFastP1; //new


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerGoal")
        {
            ScoreScript score = other.GetComponent<ScoreScript>();
            score.Player.Score++;

            UiManager.ScoreHasChanged();

           RedCarFastP1.GetComponent<PlayerCrontroller>().ResetPosition();     //new
           BlueCarFastP1.GetComponent<PlayerCrontroller>().ResetPosition();     //new

            StartCoroutine(ResetBall());
            audioManager.PlayGoal();
        }
        else if (other.tag == "Player2Goal")
        {
            ScoreScript score = other.GetComponent<ScoreScript>();
            score.Player2.Score++;

            UiManager.ScoreHasChanged();

           RedCarFastP1.GetComponent<PlayerCrontroller>().ResetPosition();     //new
           BlueCarFastP1.GetComponent<PlayerCrontroller>().ResetPosition();     //new

            StartCoroutine(ResetBall());
            audioManager.PlayGoal();
        }
    }

    //when the ball enters the goal line there is going to be audio 
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.PlayBallCollision();
        
    }
    // reset the ball, just states where the ball should go and how long it should wait before it does
    private IEnumerator ResetBall()
    {
        yield return new WaitForSecondsRealtime(0);
       
        rb.velocity = rb.position = new Vector3(3.528f, 0.534f, -0.094f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
