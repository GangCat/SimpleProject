using UnityEngine;

public interface IMouseActiveAttack : IMouseAttack
{
    public bool CanAttack { get; }

    public void Attack(Vector2 _mouseWorldPos);
}
