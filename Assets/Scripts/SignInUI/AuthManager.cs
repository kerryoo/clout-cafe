using System.Collections;
using System.Collections.Generic;
using Amazon;
using Amazon.CognitoIdentity;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        CognitoAWSCredentials credentials = new CognitoAWSCredentials(
            "us-east-1:6c841b02-010e-4c58-b410-50b08d746f87", // Identity pool ID
             RegionEndpoint.USEast1);
    }


    void Update()
    {



    }
}
