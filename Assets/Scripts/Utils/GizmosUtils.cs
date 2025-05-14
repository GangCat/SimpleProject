#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public static class GizmosUtils
{
    private const int FONT_SIZE = 20;
    public static void DrawMousePosGizmo(Color _gizmosColor, Vector2 _mouseWorldPos)
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(_mouseWorldPos, 0.2f);
#if UNITY_EDITOR
        DrawLabel(_mouseWorldPos, "Mouse Pos");
#endif
    }

    public static void DrawCircleGizmo(Color _gizmosColor, Vector2 _pos, float _radius)
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(_pos, _radius);
#if UNITY_EDITOR
        DrawLabel(_pos + Vector2.down * _radius, "explosion\nAttack");
#endif
    }

    public static void DrawSpawnAreaGizmo(float _margin)
    {
        Camera cam = Camera.main;
        if (cam == null || !cam.orthographic) return;

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        Vector3 camCenter = cam.transform.position;
        camCenter.z = 0f; // Z 0 고정 (2D용)

        Vector3 camSize = new Vector3(camWidth, camHeight, 0f);
        Vector3 spawnSize = new Vector3(camWidth + _margin * 2, camHeight + _margin * 2, 0f);

        // 카메라 시야 영역 (초록)
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(camCenter, camSize);

        // 적 스폰 영역 (빨강)
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(camCenter, spawnSize);

#if UNITY_EDITOR
        DrawLabel(camCenter + Vector3.up * (spawnSize.y / 2f + 0.5f), "Spawn Area");
#endif
    }

    private static void DrawLabel(Vector2 _mouseWorldPos, string _labelText, TextAnchor _align = TextAnchor.MiddleCenter)
    {
        var style = new GUIStyle();
        style.fontSize = FONT_SIZE;
        style.normal.textColor = Color.white;
        style.alignment = _align;

        Handles.Label(_mouseWorldPos, _labelText, style);
    }
}
