using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPointA;
    public Transform spawnPointB;
    public Transform spawnPointC;
    private Vector3[] spawnPoints = new Vector3 [3];

    private GameObject enemy;
    
    public static int enemiesOnMap = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints[0] = spawnPointA.position;
        
        spawnPoints[1] = spawnPointB.position;
        
        spawnPoints[2] = spawnPointC.position;
        
        
        for(int pos = 0 ; pos < spawnPoints.Length; pos++){
            print(spawnPoints[pos]);
        }
        // GameObject enemy= GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        // enemy.transform.position = new Vector3(59.48,1053329,-0.61);
        
        // enemy.transform.localScale = obstSize;
    }

    // Update is called once per frame
    void Update()
    {
        print("Enemies left:" + enemiesOnMap);
      if(enemiesOnMap < 3){
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = spawnPoints[Random.Range(0,3)];
      }  
    }
}
