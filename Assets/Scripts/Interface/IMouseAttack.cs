using System;

public interface IMouseAttack
{
    public void Init(IMouseWorldPosProvider _provider);
    /// <summary>
    /// �갡 false�� �ƿ� ���������� ������������
    /// </summary>
    public bool CanLevelUp { get; }

    public void LevelUp();
}