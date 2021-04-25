using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    public bool Interact;
    public Vector2 MouseInput;
    public bool TestButton;

  

    void Update()
    {
        MouseInput.x = Input.GetAxisRaw("Mouse X");
        MouseInput.y = Input.GetAxisRaw("Mouse Y");

        TestButton = Input.GetKeyDown(KeyCode.P);

        Interact = Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space);
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
    }
}
