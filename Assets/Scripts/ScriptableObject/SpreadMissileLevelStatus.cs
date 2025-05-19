using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackLevelStatus", menuName = "Scriptable Objects/AttackLevelStatus")]
public class SpreadMissileLevelStatus : ScriptableObject
{
    [SerializeField]
    private List<MissileData> missileLevelStatus = new();

    public MissileData this[int index] => missileLevelStatus[index];
}

[Serializable]
public struct MissileData
{
    public int MissileCnt;
    public float Cooltime;
    public float MissileSpeed;
    public float MissileDmg;
}