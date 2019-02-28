using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidemenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject creditmenu;

    public void hideMain() {      
        mainmenu.SetActive(false);
        creditmenu.SetActive(true);         
                         
    }

    public void showMain() {
        mainmenu.SetActive(true);
        creditmenu.SetActive(false);
    }
    
}
