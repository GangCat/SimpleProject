using UnityEngine;

public interface IMouseAttack
{
    public bool CanAttack { get; }

    /// <summary>
    /// �갡 false�� �ƿ� ���������� ������������
    /// </summary>
    public bool CanLevelUp { get; }

    public void Attack(Vector2 _mouseWorldPos);

    public void LevelUp(int _upLevel);
}
