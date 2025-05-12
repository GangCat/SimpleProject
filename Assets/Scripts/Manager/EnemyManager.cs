using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float enemySpawnDelay = 2f;

    private ObjectPoolManager poolMng = null;

    private ObjectPool enemyPool = null;

    [SerializeField]
    private string enemyPrefabPath = "Prefabs/TempEnemy.prefab";

    public void Init(ObjectPoolManager _poolMng)
    {
        poolMng = _poolMng;
        enemyPool = poolMng.PrepareObjects(enemyPrefabPath);
        StartCoroutine(nameof(SpawnEnemyCoroutine));
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while(true)
        {
            var enemyGo = enemyPool.ActivatePoolItem(); 
            enemyGo.GetComponent<TempEnemy>().Init(enemyPool, GetRandomPositionOnCircleEdge());

            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    private Vector2 GetRandomPositionOnCircleEdge(float radius = 3f)
    {
        float angle = Random.Range(0f, Mathf.PI * 2); // 0부터 2파이까지 무작위 각도
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        return new Vector2(x, y);
    }


}
