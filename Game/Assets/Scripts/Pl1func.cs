using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerFunc : IPlaneFunc
{
    public void Func()
    {
        if (GameManager.Frames % 500 == 0)
        {
            GameManager.CurrCoins += 10;
        }
    }
}

public class AttackeOneFunc : MonoBehaviour, IPlaneFunc
{
    public Arrow arrow;
    public Transform point_;
    public Transform c;
    public void Func()
    {
        if (GameManager.Frames % 100 == 0)
        {
            var a = Instantiate(arrow, point_.position, Quaternion.identity);
            a.transform.SetParent(c);
            a.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
        }
        
    }


}
public class LaserGunFunc : MonoBehaviour, IPlaneFunc
{
    public Laser laser;
    public Transform point_;
    public Transform c;
    private bool g = false;
    private Laser a = null;
    public void Func()
    {
        

        if (GameManager.Frames % 200 == 0)
        {
            a = Instantiate(laser, point_.position, Quaternion.identity);
            a.transform.SetParent(c);
            a.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        }

    }
}
public class SniperFunc : MonoBehaviour, IPlaneFunc
{
    public bullet bullet;
    public Transform point_;
    public Transform c;
    public void Func()
    {
        //if (GameManager.Frames % 100 == 0)
        //{
        //    var a = Instantiate(bullet, point_.position, Quaternion.identity);
        //    a.transform.SetParent(c);
        //    a.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
        //}

    }
}

