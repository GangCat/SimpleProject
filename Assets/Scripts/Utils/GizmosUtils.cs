using UnityEngine;

public static class GizmosUtils
{
    public static void DrawCircleGizmo(Color _gizmosColor, Vector2 _pos, float _radius)
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(_pos, _radius);
    }
}
