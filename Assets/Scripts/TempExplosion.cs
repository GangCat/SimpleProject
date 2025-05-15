using System.Collections;
using UnityEngine;

/// <summary>
/// ������ ��� ó�� ���������� �����ϰ� �ٷ� ���� �����ӿ� ���������
/// �׸��� ��� ����Ʈ�� �����־����.
/// </summary>
public class TempExplosion : MonoBehaviour, IMouseAttack
{
    [SerializeField]
    private float dmg = 1f;
    [SerializeField]
    private float radius = 3f;
    [SerializeField]
    private Color gizmoColor = Color.black;
    [SerializeField]
    private float coolTime = 2f;

    private WaitForSeconds cooltimeDelay = null;

    public bool CanAttack { get; private set; } = true;

    private readonly int ENEMY_LAYER_MASK = LayerMask.GetMask("Enemy");

    public void Init()
    {
        cooltimeDelay = new WaitForSeconds(coolTime);
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

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f, ENEMY_LAYER_MASK);
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
