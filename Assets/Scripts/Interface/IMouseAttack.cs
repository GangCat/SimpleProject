using UnityEngine;

public interface IMouseAttack
{
    public bool CanAttack { get; }
    public void Attack(Vector2 _mouseWorldPos);
}
