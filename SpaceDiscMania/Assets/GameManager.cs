using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int Enemykill = 0;

    public TextMeshProUGUI killerStat1;
    //public Text killerStat2;
   
    private void Update()
    {
        killerStat1.text = Enemykill.ToString();
        //killerStat2.text = Enemykill.ToString();
    }

    public void enemykilstat()
    {
        Enemykill++;
        Debug.Log(Enemykill);
    }
}
