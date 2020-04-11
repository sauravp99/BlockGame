using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    
    public float distanceFromWall = 0.1f;
    public float moveSpeed = 5f;

    private GameObject spawner;

    // Update is called once per frame
    // Enemy enemy = cast.transform.GetComponent<Enemy>();
            // if(enemy != null){
            //     enemy.ReduceHealth(damage);
            // }
    
    void Start() {
        SpawnEnemy.enemiesOnMap++;
    }
    void Update()
    {
        transform.Translate (0, 0, moveSpeed * Time.deltaTime);
        moveAround();
    }

    void moveAround(){
        Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			// if (hitObject.GetComponent<PlayerInfo> ()) {
				// if (_paintball == null) {
				// 	_paintball = Instantiate (paintballPrefab) as GameObject;
				// 	_paintball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
				// 	_paintball.transform.rotation = transform.rotation;
				// }
            if (hit.distance <= distanceFromWall) {
                moveSpeed = 0f;
				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
                moveSpeed = 5f;
			}
			} //else
		}
    //}
    public void ReduceHealth(float damagePoint){
        health -= damagePoint;
        if(health <= 0f){
           Despawn(); 
        }
    }
    void Despawn(){
        SpawnEnemy.enemiesOnMap--;
        Destroy(gameObject);

    }
}


// public float speed = 3.0f;
// 	public float obstacleRange = 5.0f;

// 	private bool _alive;

// 	public GameObject paintballPrefab;
// 	private GameObject _paintball;

// 	void Start () {
// 		_alive = true;
// 	}

// 	void Update () {
// 		if (_alive) {
// 			transform.Translate (0, 0, speed * Time.deltaTime);
// 		}

// 		Ray ray = new Ray (transform.position, transform.forward);
// 		RaycastHit hit;
// 		if (Physics.SphereCast (ray, 0.75f, out hit)) {
// 			GameObject hitObject = hit.transform.gameObject;
// 			if (hitObject.GetComponent<PlayerInfo> ()) {
// 				if (_paintball == null) {
// 					_paintball = Instantiate (paintballPrefab) as GameObject;
// 					_paintball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
// 					_paintball.transform.rotation = transform.rotation;
// 				}
// 			} else if (hit.distance < obstacleRange) {
// 				float angle = Random.Range (-110, 110);
// 				transform.Rotate (0, angle, 0);
// 			}
// 		}
// 	}

// 	public void SetAlive(bool alive) {
// 		_alive = alive;
// 	}
