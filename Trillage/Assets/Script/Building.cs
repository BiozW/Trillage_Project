using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost;

    public int goldIncrease;
    public int goldDecrease;
    public int waterIncrease;
    public int waterDecrease;
    public int powerIncrease;
    public int powerDecrease;

    public float timeBtwIncreases;
    private float nextIncreaseTime;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncreases;
            gm.gold += goldIncrease;
            gm.power += powerIncrease;
            gm.water += waterIncrease;
            gm.gold -= goldDecrease;
            gm.power -= powerDecrease;
            gm.water -= waterDecrease;
        }
    }
}
