using System;

public interface IMouseAttack
{
    public void Init(IMouseWorldPosProvider _provider);
    /// <summary>
    /// 얘가 false면 아예 선택지에서 지워버려야함
    /// </summary>
    public bool CanLevelUp { get; }

    public void LevelUp();
}