using UnityEngine;
using UnityEngine.UI;

public class SpawnPrefabOnClick : MonoBehaviour
{
    public GameObject prefabToSpawn;
    
    public Vector3 spawnPosition;

    private void Start()
    {
        
	
    }

    public void SpawnPrefab()
    {
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
