using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaticiGhost : MonoBehaviour
{
    public GameObject UprageCanvas;
    int Dash, Jump;
    public GameObject Non;

    private void Start()
    {
        Dash = PlayerPrefs.GetInt("DashActive");
        Jump = PlayerPrefs.GetInt("DoubleJump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Cursor.visible = true;
            UprageCanvas.SetActive(true);
        }
        if (Dash > 0 && Jump > 0)
        {
            Non.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            UprageCanvas.SetActive(false);
            Cursor.visible = false;
        }

           Non.SetActive(false);
        
    }


}
