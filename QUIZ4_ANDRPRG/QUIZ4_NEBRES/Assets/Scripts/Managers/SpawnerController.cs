using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public static SpawnerController Instance;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();

	private void Awake()
	{
		Instance = this;
	}
	// Start is called before the first frame update
	void Start()
    {
        
        for (int i = 0; i < 5; i++) 
        {
			SpawnEnemy(1);
		}
            
    }

    void SpawnEnemy(int idx)
    {
        GameObject enemyObj = (GameObject)Instantiate(enemyPrefab[idx]);
        enemyObj.transform.position = spawnPoint.position;
        enemyObj.GetComponent<Enemy>().SetTarget(GameManager.Instance.CrystalCore.transform);
        enemyList.Add(enemyObj);
    }

    public void RemoveEnemy(GameObject obj)
    {
		enemyList.Remove(obj);

	}
}
