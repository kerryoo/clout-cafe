using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIScript : MonoBehaviour
{

    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;


    private readonly float m_interpolation = 10;
    private readonly float m_backwardRunScale = 0.66f;
    private readonly float targetPositionTolerance = 3f;
    private Vector3 targetPosition;

    private float startWalking = 0f;
    private float period = 10f;

    float m_currentV, m_currentH, v, h = 0;

    private void Start()
    {
        m_animator.SetBool("Grounded", true);
        
    }
    void Update()
    {
        m_animator.SetFloat("MoveSpeed", 0.5f);
        WanderAimlessly();
    }
    void MoveCharacter()
    {
        

        

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * 2 * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        
    }

    public virtual void WanderAimlessly()
    {
        if (Vector3.Distance(targetPosition, transform.position) <= targetPositionTolerance)
        {
            GetNextPosition();
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);

        Vector3 nextPosition = new Vector3(0, 0, 1 * Time.deltaTime);

        transform.Translate(nextPosition);
    }
    public virtual void GetNextPosition()
    {
        targetPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
