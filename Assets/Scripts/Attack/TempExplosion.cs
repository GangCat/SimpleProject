using System.Collections;
using UnityEngine;

/// <summary>
/// ������ ��� ó�� ���������� �����ϰ� �ٷ� ���� �����ӿ� ���������
/// �׸��� ��� ����Ʈ�� �����־����.
/// </summary>
public class TempExplosion : MonoBehaviour, IMouseActiveAttack
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

    [SerializeField]
    private ExplosionLevelStatus explosionLevelStatusSO = null;

    private Coroutine cooltimeCoroutine = null;
    private WaitForSeconds cooltimeDelay = null;

    public bool CanAttack { get; private set; } = true;
    public bool CanLevelUp { get; private set; } = true;

    private int EnemyLayerMask = -1;

    public void Init()
    {
        EnemyLayerMask = LayerMask.GetMask("Enemy");

        SetStatusByLevel();
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

        SetStatusByLevel();
    }


    private void SetStatusByLevel()
    {
        var status = explosionLevelStatusSO[level];
        dmg = status.dmg;
        radius = status.radius;
        coolTime = status.cooltime;

        // �̰� �ٲ㵵 �̹� ������ ����ϰ� �־��ٸ� �� �������� ��Ÿ�� ���� �ȵ� ä�� ���ư�
        // �ٵ� ū ���� ������?
        // �غ��� 0.���� ���̶� ����
        cooltimeDelay = new WaitForSeconds(coolTime);
    }

    public void Attack(Vector2 _mouseWorldPos)
    {
        AttackCycle(_mouseWorldPos);

        cooltimeCoroutine = StartCoroutine(nameof(CooltimeCoroutine));
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
