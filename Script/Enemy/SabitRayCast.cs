using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabitRayCast : MonoBehaviour
{
    public LayerMask layer;
    Animator anim;
    float Leftbekle;
    float RightBekle;
    private void Awake()
    {
        Leftbekle = 2;
        RightBekle = 2;
        anim = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {

        if (Physics2D.Raycast(transform.position,Vector2.right,0.8f,layer))
        {
            if (Leftbekle >= 2)
            {
                anim.SetBool("Left", true);
                Leftbekle = 0;
            }
            else
                anim.SetBool("Left", false);
        }
       
        Leftbekle += Time.deltaTime;
        RightBekle += Time.deltaTime;
       
        
        if (Physics2D.Raycast(transform.position, -Vector2.right,0.8f, layer))
        {
            if (RightBekle >= 2)
            {
                anim.SetBool("Right", true);
                RightBekle = 0;
            }
            else
                anim.SetBool("Right", false);
        }
    }
 
}
