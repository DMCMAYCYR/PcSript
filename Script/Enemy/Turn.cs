using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    public LayerMask layer;

    private void FixedUpdate()
    {

        if (Physics2D.Raycast(transform.position, Vector2.right, 5f, layer))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if (Physics2D.Raycast(transform.position, -Vector2.right, 5f, layer))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
