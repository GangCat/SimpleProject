using System;
using System.Collections;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 1f;
    [SerializeField]
    private float curHp = 1f;

    private ObjectPool pool = null;

    private bool isAlive = false;

    private Vector2 castlePos = Vector2.zero;

    public void Init(ObjectPool _pool, Vector2 _pos)
    {
        pool = _pool;
        transform.position = _pos;
        isAlive = true;
        StartCoroutine(nameof(MoveToCastleCoroutine));
    }

    public void Damaged(float dmg)
    {
        curHp -= dmg;
        if(curHp <= 0)
        {
            isAlive = false;
            pool.DeactivatePoolItem(gameObject);
        }
    }

    private IEnumerator MoveToCastleCoroutine()
    {
        // 방향은 항상 0,0 방향이기 때문에 자기 포지션의 역임
        Vector2 dir = -transform.position;
        while(isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, 1f * Time.deltaTime);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
