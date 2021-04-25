using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InteractController : MonoBehaviour
{
    [SerializeField] InputController inputController;
    private float radius = 1.5f;

    private void Update()
    {
        if (inputController.Interact)
        {
            
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("NPC"))
                {
                    Debug.Log("Interaction with NPC fired");
                }
            }
        }
    }
}
