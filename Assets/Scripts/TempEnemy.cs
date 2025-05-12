using System;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 1f;
    [SerializeField]
    private float curHp = 1f;

    private ObjectPool pool = null;

    public void Init(ObjectPool _pool, Vector2 _pos)
    {
        pool = _pool;
        transform.position = _pos;
    }

    public void Damaged(float dmg)
    {
        curHp -= dmg;
        if(curHp <= 0)
        {
            pool.DeactivatePoolItem(gameObject);
        }
    }
}
