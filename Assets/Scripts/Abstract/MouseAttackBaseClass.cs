using UnityEngine;
using System.Collections;

public abstract class MouseAttackBaseClass : MonoBehaviour, IMouseAttack
{
    [SerializeField]
    protected float coolTime = 2f;

    protected WaitForSeconds cooltimeDelay = null;
    public bool CanAttack { get; protected set; } = true;

    public virtual void Attack(Vector2 _mouseWorldPos)
    {
        AttackCycle(_mouseWorldPos);

        StartCoroutine(nameof(CooltimeCoroutine));
    }

    protected abstract void AttackCycle(Vector2 _mouseWorldPos);

    public virtual void Init()
    {
        cooltimeDelay = new WaitForSeconds(coolTime);
    }

    protected IEnumerator CooltimeCoroutine()
    {
        CanAttack = false;
        yield return cooltimeDelay;
        CanAttack = true;
    }
}
