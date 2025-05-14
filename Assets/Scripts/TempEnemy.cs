using System;
using System.Collections;
using UnityEngine;

public class TempEnemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float maxHp = 1f;
    [SerializeField]
    private float curHp = 1f;

    [SerializeField]
    private float damage = 5f;

    [SerializeField]
    private float moveSpeed = 1f;

    private ObjectPool pool = null;
    private bool isAlive = false;

    public void Init(ObjectPool _pool, Vector2 _pos)
    {
        pool = _pool;
        transform.position = _pos;
        isAlive = true;
        StartCoroutine(nameof(MoveToCastleCoroutine));
        transform.up = (-transform.position).normalized; // �� �ٶ󺸵�����
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
        // ������ �׻� 0,0 �����̱� ������ �ڱ� �������� ����
        while(isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, moveSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damagable = collision.GetComponent<IDamagable>();
        damagable?.Damaged(damage);
    }
}
