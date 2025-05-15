using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpreadMissile : MonoBehaviour, IMouseAttack
{
    [SerializeField]
    private AttackLevelStatus missileLevelStatusSO = null;

    [SerializeField]
    private int level = 0;
    [SerializeField]
    private int maxLevel = 5;
    [SerializeField]
    private float coolTime = 2f;

    [SerializeField]
    private int missileCnt = 3;
    [SerializeField]
    private float missileDmg = 1f;
    [SerializeField]
    private float missileDisappearTime = 3f;
    [SerializeField]
    private float missileMoveSpeed = 3f;

    private WaitForSeconds cooltimeDelay = null;

    public bool CanAttack { get; private set; } = true;
    public bool CanLevelUp { get; private set; } = true;

    private TempMissile[] missileArr = null;

    

    public void Init()
    {
        SetStatusByLevel();
        cooltimeDelay = new WaitForSeconds(coolTime);
        missileArr = GetComponentsInChildren<TempMissile>();
        for(int i = 0; i < missileArr.Length; ++i)
        {
            missileArr[i].Init(missileDmg, missileDisappearTime, missileMoveSpeed);
        }
    }

    public void Attack(Vector2 _mouseWorldPos)
    {
        for(int i = 0; i < missileCnt; ++i)
        {
            var launchDir = -SpawnUtils.GetRandomPositionOnCircleEdge();
            missileArr[i].Launch(_mouseWorldPos, launchDir.normalized);
        }

        StartCoroutine(nameof(CooltimeCoroutine));
    }

    private IEnumerator CooltimeCoroutine()
    {
        CanAttack = false;
        yield return cooltimeDelay;
        CanAttack = true;
    }

    public void LevelUp(int _upLevel)
    {
        level += _upLevel;

        if(level >= maxLevel)
        {
            level = maxLevel;
            CanLevelUp = false;
        }

        SetStatusByLevel();

        for(int i = 0; i < missileArr.Length; ++i)
        {
            missileArr[i].Upgrade(missileDmg, missileDisappearTime, missileMoveSpeed);
        }
    }

    private void SetStatusByLevel()
    {
        var status = missileLevelStatusSO[level];
        missileCnt = status.MissileCnt;
        coolTime = status.Cooltime;
        missileMoveSpeed = status.MissileSpeed;
        missileDmg = status.MissileDmg;
        missileDisappearTime = coolTime - 1f;
    }
}
