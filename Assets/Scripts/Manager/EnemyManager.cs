using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float enemySpawnDelay = 2f;

    private ObjectPool enemyPool = null;

    private ICommand showDamageTextCommand;

    [SerializeField]
    private string enemyPrefabPath = "Prefabs/TempEnemy.prefab";

    public void Init(ICommand _showDamageTextCommand)
    {
        var poolMng = ObjectPoolManager.Instance;
        enemyPool = poolMng.PrepareObjects(enemyPrefabPath);
        showDamageTextCommand = _showDamageTextCommand;
        StartCoroutine(nameof(SpawnEnemyCoroutine));
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while(true)
        {
            var enemyGo = enemyPool.ActivatePoolItem(); 
            enemyGo.GetComponent<TempEnemy>().Init(enemyPool, SpawnUtils.GetRandomPointOutsideCamera2D(), showDamageTextCommand);

            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }



    private void OnDrawGizmos()
    {
        GizmosUtils.DrawSpawnAreaGizmo(2);
    }


}
