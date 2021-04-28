using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] InputController inputController;
    [SerializeField] PlayerSettings playerSettings;

    [SerializeField] private float m_moveSpeed = 4;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private void Start()
    {
        m_animator.SetBool("Grounded", true);
    }
    void Update()
    {
        MoveCharacter();
    }
    void MoveCharacter()
    {
        float v = inputController.Vertical;
        float h = inputController.Horizontal;

        bool walk = !inputController.Run;

        if (v < 0)
        {
            if (walk) { v *= m_backwardsWalkScale; }
            else { v *= m_backwardRunScale; }
        }
        else if (walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV);
    }
}
