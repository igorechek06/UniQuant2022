using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mode : MonoBehaviour
{
    public TMP_Dropdown lis;
    static public int money;
    static public int frfr;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lis.value == 0)
        {
            money = 100;
            frfr = 700;
        }
        if (lis.value == 1)
        {
            money = 80;
            frfr = 600;
        }
        if (lis.value == 2)
        {
            money = 80;
            frfr = 500;
        }
        if (lis.value == 3)
        {
            money = 60;
            frfr = 600;
        }
    }
}
