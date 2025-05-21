using UnityEngine;

public class CanvasDamageText : MonoBehaviour, ICanvasDamageText
{
    // 오브젝트 풀링으로 텍스트를 가져올거임
    // 가져온 텍스트는 이 캔버스의 자식으로 넣을거임
    // 사용 끝나면 반납할 때 다시 매이저 자식으로 돌아가게 할듯

    // 적들이 공격받으면 띄워줘야함
    [SerializeField]
    private string textPath = "";

    private ObjectPool damageTextPool = null;

    public void Init()
    {
        damageTextPool = ObjectPoolManager.Instance.PrepareObjects(textPath);
    }

    public void ShowDamageText(Vector2 _pos)
    {
        var text = damageTextPool.ActivatePoolItem();
        text.GetComponent<DamageText>().Init(transform, _pos, damageTextPool);
    }
}
