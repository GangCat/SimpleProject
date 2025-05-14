using UnityEngine;

public static class SpawnUtils
{
    public static Vector2 GetRandomPositionOnCircleEdge(float radius = 3f)
    {
        float angle = Random.Range(0f, Mathf.PI * 2); // 0부터 2파이까지 무작위 각도
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        return new Vector2(x, y);

    }

    public static Vector2 GetRandomPointOutsideCamera2D(float margin = 2f)
    {
        Camera cam = Camera.main;
        if (!cam.orthographic)
        {
            Debug.LogError("이 함수는 2D orthographic 카메라에서만 사용할 수 있습니다.");
            return Vector2.zero;
        }

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        Vector2 camCenter = cam.transform.position;
        float halfWidth = camWidth / 2f;
        float halfHeight = camHeight / 2f;

        int side = Random.Range(0, 4); // 0: Top, 1: Right, 2: Bottom, 3: Left
        float x = 0f;
        float y = 0f;

        switch (side)
        {
            case 0: // Top
                x = Random.Range(camCenter.x - halfWidth, camCenter.x + halfWidth);
                y = camCenter.y + halfHeight + margin;
                break;
            case 1: // Right
                x = camCenter.x + halfWidth + margin;
                y = Random.Range(camCenter.y - halfHeight, camCenter.y + halfHeight);
                break;
            case 2: // Bottom
                x = Random.Range(camCenter.x - halfWidth, camCenter.x + halfWidth);
                y = camCenter.y - halfHeight - margin;
                break;
            case 3: // Left
                x = camCenter.x - halfWidth - margin;
                y = Random.Range(camCenter.y - halfHeight, camCenter.y + halfHeight);
                break;
        }

        return new Vector2(x, y);
    }
}
