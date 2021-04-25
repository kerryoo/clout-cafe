using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] InputController inputController;
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] Animator animator;

    private float currentV, currentH;
    private readonly float backwardsScale = 0.66f;
    private readonly float interpolation = 3f;
    private readonly float moveSpeed = 3f;

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {

        float xDirection = inputController.Vertical;
        float yDirection = inputController.Horizontal;

        

        if (xDirection < 0)
        {
            xDirection *= backwardsScale;
        }

        currentV = Mathf.Lerp(currentV, xDirection, Time.deltaTime * interpolation);
        currentH = Mathf.Lerp(currentH, yDirection, Time.deltaTime * interpolation);

        if (inputController.TestButton)
        {
            Debug.Log(currentV);
        }

        animator.SetFloat("speed", currentV);

        transform.position += transform.forward * currentV * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * yDirection);
    }
}
