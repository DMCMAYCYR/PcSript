using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Bu özel bir oda da olacak oraya girdikmi savaş başalyacak. 2 Şekilde saldıracak önce sadece alev sonra kuyruğunu sallayarak rüzgar atacaz bize. Damage attığımızda tepki vermeyecek.

    Transform target;
    GameObject Target;
    public float StopDistance;
    public int moveSpeed;
     Animator anim;
    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        target = Target.transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > StopDistance)
        {

            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, target.position) < StopDistance)
        {
            anim.SetTrigger("attack1");
        }
    }
}
