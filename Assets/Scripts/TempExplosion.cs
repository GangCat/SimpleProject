using UnityEngine;

public class TempExplosion : MonoBehaviour
{
    [SerializeField]
    private float dmg = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<TempEnemy>();
        enemy.Damaged(dmg);
        Debug.Log("Trigger");
    }
}
