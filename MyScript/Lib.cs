using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Guninfo
{
    public enum Gun_Type
    {
        Gun_Pistol,
        Gun_AR,
        Gun_ShotGun,
        Gun_Submachine,
        Gun_Rifle,
        Gun_RPG
    }
    public Gun_Type guntype;
    public float damage;
    public float shotspeed;
    public int maxAmmo;
    public float accuracy;
    public float rechargespeed;
};

[System.Serializable]
public class SkillInfo
{
    public enum Skill_Type
    {
        Pas_dmg,
        Pas_speed,
        Pas_move,
        Pas_health,
        Pas_accr,
        Pas_charge,

        Act_Firetime,
        Act_Deadattack,
        Act_Recovery
    }
    public const int Pasnum = 6;
    public const int Actnum = 3;
    public Skill_Type skillType;
    public float value;
};