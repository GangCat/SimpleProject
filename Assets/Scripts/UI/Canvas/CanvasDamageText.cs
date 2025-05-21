using UnityEngine;

public class CanvasDamageText : MonoBehaviour, ICanvasDamageText
{
    // ������Ʈ Ǯ������ �ؽ�Ʈ�� �����ð���
    // ������ �ؽ�Ʈ�� �� ĵ������ �ڽ����� ��������
    // ��� ������ �ݳ��� �� �ٽ� ������ �ڽ����� ���ư��� �ҵ�

    // ������ ���ݹ����� ��������
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
