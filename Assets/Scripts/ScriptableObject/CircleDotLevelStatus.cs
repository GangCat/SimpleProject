using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleDotLevelStatus", menuName = "Scriptable Objects/CircleDotLevelStatus")]
public class CircleDotLevelStatus : ScriptableObject
{
    [SerializeField]
    private List<CircleData> missileLevelStatus = new();

    public CircleData this[int index] => missileLevelStatus[index];
}

[Serializable]
public struct CircleData
{
    public float dmg;
    public float radius;
}