using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChacterUpdate : MonoBehaviour
{
  
    public Button doubleJumpimage;
    public Button DashImage;
    public GameObject doubleGame;
    public GameObject dasgGame;
    public ChacterChontrol chacterChontrol;
    int Jump, Dash;

    public bool Sil;

    private void Awake()
    {
        Jump = PlayerPrefs.GetInt("DoubleJump");
        Dash = PlayerPrefs.GetInt("DashActive");
        if (Dash>0 )
        {
            dasgGame.SetActive(false);
        }
        if (Jump>0)
        {
            doubleGame.SetActive(false);
        }
    
        
    }

    private void Update()
    {
        if(Sil)
            PlayerPrefs.DeleteAll();
    }

    public void DashUprage()
    {
        if (Dash <= 0)
        {

            if (chacterChontrol.MagmaMeyvesi >= 200)
            {
                DashImage.enabled = false;
                PlayerPrefs.SetInt("DashActive", 1);
                chacterChontrol.dashActive = 1;
                chacterChontrol.MagmaMeyvesi -= 200;
            }
        }     
    }

    public void JumpUprage()
    {
        if (Jump <= 0)
        {

            if (chacterChontrol.MagmaMeyvesi >= 150)
            {
                doubleJumpimage.enabled = false;
                PlayerPrefs.SetInt("DoubleJump", 1);
                chacterChontrol.extraJumps = 1;
                chacterChontrol.MagmaMeyvesi -= 150;
            }
        }
    }

}
