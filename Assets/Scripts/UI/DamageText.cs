using UnityEngine;

public class DamageText : MonoBehaviour
{
    private ObjectPool pool = null;
    public void Init(Transform _parent, Vector2 _targetPos, ObjectPool _pool)
    {
        transform.SetParent(_parent);
        var screenPos = Camera.main.WorldToScreenPoint(_targetPos);

        pool = _pool;
        GetComponent<RectTransform>().anchoredPosition = screenPos;
    }
}
