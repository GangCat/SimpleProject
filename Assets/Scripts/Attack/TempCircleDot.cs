using System.Collections;
using UnityEngine;

public class TempCircleDot : MonoBehaviour, IMousePassiveAttack
{
    [SerializeField]
    private float dmg = 0.5f;
    [SerializeField]
    private int level = 0;
    [SerializeField]
    private int maxLevel = 7;
    [SerializeField]
    private float radius = 1f;
    [SerializeField]
    private Color gizmoColor = Color.black;
    [SerializeField]
    private float dotInterval = 0.5f;

    private int EnemyLayerMask = -1;

    private IMouseWorldPosProvider mouseWorldPosProvider = null;

    public void Init(IMouseWorldPosProvider _mouseWorldPosProvider)
    {
        mouseWorldPosProvider = _mouseWorldPosProvider;
        EnemyLayerMask = LayerMask.GetMask("Enemy");
        StartCoroutine(nameof(AttackCoroutine));
    }

    private IEnumerator AttackCoroutine()
    {
        while(true)
        {
            Attack();
            yield return new WaitForSeconds(dotInterval);
        }
    }

    private void Attack()
    {
        transform.position = mouseWorldPosProvider.MouseWorldPos;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f, EnemyLayerMask);
        foreach (var hit in hits)
        {
            var damagable = hit.collider.GetComponent<IDamagable>();
            damagable?.Damaged(dmg);
        }
    }

}
