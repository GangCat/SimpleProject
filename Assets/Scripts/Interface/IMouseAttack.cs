using UnityEngine;

public interface IMouseAttack
{
    public bool CanAttack { get; }

    /// <summary>
    /// 얘가 false면 아예 선택지에서 지워버려야함
    /// </summary>
    public bool CanLevelUp { get; }

    public void Attack(Vector2 _mouseWorldPos);

    public void LevelUp(int _upLevel);
}
