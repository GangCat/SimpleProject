using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour, IMouseWorldPosProvider
{
    private Camera cam = null;

    public Vector2 MouseWorldPos
    {
        get
        {
            return cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void Init()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void OnDrawGizmos()
    {
        if(Application.isPlaying)
            GizmosUtils.DrawMousePosGizmo(Color.blue, MouseWorldPos);
    }
}
