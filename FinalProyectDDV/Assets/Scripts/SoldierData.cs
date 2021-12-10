using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New SoldierData", menuName ="Soldier Data")]
public class SoldierData : ScriptableObject
{
    [SerializeField] private float distanceRay;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float timeShoot;
    [SerializeField] private float hp;
    [SerializeField] private float shield;
    [SerializeField] private float damage;
    

    public float DistanceRay
    {
        get
        {
            return distanceRay;
        }
    }

    public float ShootCoolDown
    {
        get
        {
            return shootCooldown;
        }
    }

    public float TimeShoot
    {
        get
        {
            return timeShoot;
        }
    }

    public float Hp
    {
        get
        {
            return hp;
        }
    }

    public float Shield
    {
        get
        {
            return shield;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public void IncreaseTimeShoot(float time)
    {
    
        timeShoot += time;
    

    }

    public void NullTimeShoot()
    {
    
        timeShoot = 0;

    }

    public void DecreaseHp(float Amount)
    {
        hp = hp - Amount;
    }

    public void SetHp(float Amount)
    {
        hp = Amount;
    }
}
