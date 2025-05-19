using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionLevelStatus", menuName = "Scriptable Objects/ExplosionLevelStatus")]
public class ExplosionLevelStatus : ScriptableObject
{
    [SerializeField]
    private List<ExplosionData> explosionLevelStatus = new();

    public ExplosionData this[int index] => explosionLevelStatus[index];
}

[Serializable]
public struct ExplosionData
{
    public float dmg;
    public float Cooltime;
    public float radius;
    public float MissileDmg;
}