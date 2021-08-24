using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ammotext;
   

    public void UpdateAmmo(int count)
    {
        _ammotext.text = "" + count;
    }
   
   
   
    
}
