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
            enemyGo.GetComponent<TempEnemy>().Init(enemyPool, SpawnUtils.GetRandomPointOutsideCamera2D());

            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }



    private void OnDrawGizmos()
    {
        GizmosUtils.DrawSpawnAreaGizmo(2);
    }


}
