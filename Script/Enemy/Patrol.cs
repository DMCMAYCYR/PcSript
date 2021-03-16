using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    bool movingRgiht = true;
    public Transform graundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(graundDetection.position, Vector2.down,2f);
        if (groundInfo.collider == false)
        {
            if (movingRgiht==true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRgiht = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRgiht = true;
            }
        }
        

      
    }

}
