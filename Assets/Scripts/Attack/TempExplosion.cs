using System.Collections;
using UnityEngine;

/// <summary>
/// 폭발의 경우 처음 나왔을때만 공격하고 바로 다음 프레임에 사라질거임
/// 그리고 대신 이펙트는 남아있어야함.
/// </summary>
public class TempExplosion : MonoBehaviour, IMouseAttack
{
    [SerializeField]
    private float dmg = 1f;
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private int maxLevel = 1;
    [SerializeField]
    private float radius = 1f;
    [SerializeField]
    private Color gizmoColor = Color.black;
    [SerializeField]
    private float coolTime = 2f;

    private WaitForSeconds cooltimeDelay = null;

    public bool CanAttack { get; private set; } = true;
    public bool CanLevelUp { get; private set; } = true;

    private int EnemyLayerMask = -1;

    public void Init()
    {
        EnemyLayerMask = LayerMask.GetMask("Enemy");
        cooltimeDelay = new WaitForSeconds(coolTime);
    }

    public void LevelUp(int _upLevel)
    {
        level += _upLevel;
        if (level >= maxLevel)
        {
            level = maxLevel;
            CanLevelUp = false;
        }
    }

    public void Attack(Vector2 _mouseWorldPos)
    {
        AttackCycle(_mouseWorldPos);

        StartCoroutine(nameof(CooltimeCoroutine));
    }

    private IEnumerator CooltimeCoroutine()
    {
        CanAttack = false;
        yield return cooltimeDelay;
        CanAttack = true;
    }

    private void AttackCycle(Vector2 _mouseWorldPos)
    {
        transform.position = _mouseWorldPos;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f, EnemyLayerMask);
        foreach (var hit in hits)
        {
            var damagable = hit.collider.GetComponent<IDamagable>();
            damagable?.Damaged(dmg);
        }
    }

    private void OnDrawGizmos()
    {
        GizmosUtils.DrawCircleGizmo(gizmoColor, transform.position, radius);
    }

}
