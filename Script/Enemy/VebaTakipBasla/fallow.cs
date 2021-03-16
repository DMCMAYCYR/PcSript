using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallow : MonoBehaviour
{
    public  bool TakipEt=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            TakipEt = true;
        }
    }

    //Burada raycst yollayalım raycastten uzaksa öyle takipet false olsun collision'dan çıkınca raycast yolla  
    //private void OnTriggerExit2D(Collider2D collision)
    //{

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        TakipEt = false;
    //    }
    //}
}
