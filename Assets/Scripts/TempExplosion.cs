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
    private float coolTime = 2f;
    [SerializeField]
    private float radius = 3f;

    private WaitForSeconds cooltimeDelay = null;

    private int enemyLayerMask = -1;

    public bool CanAttack { get; private set; } = true;

    public void Init()
    {
        cooltimeDelay = new WaitForSeconds(coolTime);
        enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    public void Attack(Vector2 _mouseWorldPos)
    {
        transform.position = _mouseWorldPos;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f, enemyLayerMask);
        foreach (var hit in hits)
        {
            var damagable = hit.collider.GetComponent<IDamagable>();
            damagable?.Damaged(dmg);
        }

        StartCoroutine(nameof(CooltimeCoroutine));
    }

    private IEnumerator CooltimeCoroutine()
    {
        CanAttack = false;
        yield return cooltimeDelay;
        CanAttack = true;
    }

    private void OnDrawGizmos()
    {
        GizmosUtils.DrawCircleGizmo(Color.red, transform.position, radius);
    }

}
