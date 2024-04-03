using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, StatData> stat = new Dictionary<int, StatData>();
    public HashSet<BulletController> bullets = new HashSet<BulletController>();


    public StatData Setting(bool isPlayer, int max, int current, int bulletDMG, int bulletLV, int moveSPD)
    {

        StatData data = new StatData();
        data.maxHp = max;
        data.currentHp = current;
        data.bulletDamage = bulletDMG;
        data.bulletLevel = bulletLV;
        data.moveSpeed = moveSPD;

        if( isPlayer)
        {
            Init(data, 0);
        }
        else
        {
            Init(data, stat.Count);
                
                
                
                
        }
        return data;
    
    
    
    
    
    }







    public void Init(StatData data , int CreatureNumber)
    {

        if(stat.ContainsKey(CreatureNumber))
        {
            if(stat[CreatureNumber]==data)
            { }
            else
            {
                Debug.LogWarning($"이미있음{CreatureNumber}를 가진 몬스터가 데이터에 하지만 번호가 달라요");
                Init(data, CreatureNumber + 1);
            }

        }
        else
        {

            stat.Add(CreatureNumber, data);
        }
    }
}

public class StatData
{
    public float maxHp;
    public float currentHp;
    public int bulletDamage;
    public int bulletLevel;
    public int moveSpeed;
}
