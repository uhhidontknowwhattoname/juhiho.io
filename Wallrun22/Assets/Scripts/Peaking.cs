using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaking : MonoBehaviour
{
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(0f, .0f, 3f);
        }
            
        else if (Input.GetKey(KeyCode.E))
        {

        }
            
    }

}

