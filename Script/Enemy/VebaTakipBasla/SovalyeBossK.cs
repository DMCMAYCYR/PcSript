using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SovalyeBossK : MonoBehaviour
{
    Transform target;
    GameObject Target;
    public int moveSpeed;
    public LayerMask layer;
    public Animator anim;
    public float StopDistance;
    bool Fallow;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        target = Target.transform;
    }
    void Update()
    {
        Fallow = GetComponentInChildren<fallow>().TakipEt;
        if (Fallow)
        {

            if (Vector2.Distance(transform.position, target.position) > StopDistance)
            {

                Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, target.position) < StopDistance)
            {
                anim.SetTrigger("attack");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Çalışıyor buraya damage yap bize vurduğunda buradna damage yiyecez
    }


}
