using System.Collections;
using UnityEngine;

/// <summary>
/// ������ ��� ó�� ���������� �����ϰ� �ٷ� ���� �����ӿ� ���������
/// �׸��� ��� ����Ʈ�� �����־����.
/// </summary>
public class TempExplosion : MouseAttackBaseClass
{
    [SerializeField]
    private float dmg = 1f;
    [SerializeField]
    private float radius = 3f;
    [SerializeField]
    private Color gizmoColor = Color.black;

    private int enemyLayerMask = -1;

    public override void Init()
    {
        base.Init();
        enemyLayerMask = LayerMask.GetMask("Enemy");
    }
    
    protected override void AttackCycle(Vector2 _mouseWorldPos)
    {
        transform.position = _mouseWorldPos;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f, enemyLayerMask);
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
