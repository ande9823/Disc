using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StatUpdate : MonoBehaviour
{
    //public GameObject killText;
    //public GameObject fallText;

    public TextMeshProUGUI faller;
    public TextMeshProUGUI killer;

    //TextMeshProUGUI killer;
    //TextMeshProUGUI faller;
    
    public int Enemykill;
    public int TimesFall;



    // Start is called before the first frame update
    void Start()
    {
        killer.GetComponent<TextMeshProUGUI>();
        faller.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        killer.text = Enemykill.ToString();
        faller.text = Enemykill.ToString();
    }

    public void enemyWasKilled()
    {
        TimesFall++;
    }

    public void playerHasFallen() 
    {
        Enemykill++;
        Debug.Log("Enemy was killed");
    }
}
