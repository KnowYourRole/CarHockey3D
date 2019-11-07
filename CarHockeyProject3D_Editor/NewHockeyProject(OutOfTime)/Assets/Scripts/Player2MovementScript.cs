using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player2MovementScript : MonoBehaviour
{
    public int Score = 0;

    public string VerticalAxis;
    public string HorizontalAxis;

    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public Vector3 PlayersSpawn;   //new
   


    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        PlayersSpawn = transform.position;   //new
        
    }

    private void OnEnable()
    {
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        //m_Rigidbody.isKinematic = true;
    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis(VerticalAxis);
        m_TurnInputValue = Input.GetAxis(HorizontalAxis);

    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    public void ResetPosition()
    {

        transform.position = PlayersSpawn;  //new
        
    }

   

}
