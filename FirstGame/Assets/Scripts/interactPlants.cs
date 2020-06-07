using UnityEngine;

public class interactPlants : MonoBehaviour { //Change name: bucket_interaction

    private int timesPoured = 0;
    public bool bucketEmpty = true;
    public GameObject renderedWater;
    public GameObject player;
    public Transform defaultWaterSpawn;
    private float timePassed;
    private int timer = 0;
    //Test
    float tempTime = 0;

    void Update() {
        
        if (bucketEmpty == false) {
            // print("decreasing water!!!");
            decreaseWaterLevel();
        }

        // Debug: checkValue();
    }

    // private void FixedUpdate() {

    //     decreaseWaterLevel();   
    // }

    void decreaseWaterLevel() { //Moves renderedWater -0.015f down Y axis every sec
        
        timePassed += Time.deltaTime;
        
        if (timePassed > 1) { 
            
            timer++;
            // print(timer++); //todo: stop timer after bucketEmpty -> true
            timePassed -= 1;
            decrease();

            if (timer == 20) {

                emptyBucket();
            }
        }
    }

    void decrease() {

        renderedWater.transform.position = renderedWater.transform.position + new Vector3(0,-0.015f,0); //(0,-0.15f,0)
    }

    public void pourWater() {

        timesPoured++;
        decrease();

        if (timesPoured == 6) {

            emptyBucket();
        }
    }

    public void fillWater() {

        //todo: Fill water from container 
        renderedWater.SetActive(true);
        renderedWater.transform.position = defaultWaterSpawn.position;
        bucketEmpty = false;
    }

    void emptyBucket() {

        bucketEmpty = true;
        timesPoured = 0;
        renderedWater.SetActive(false);
        print("Bucket emptied");
        player.GetComponent<PlayerCollision>().deactivatePlants();
        /**todo:
            - switch animation to stop water pouring from bucket hole
            - display "bucket empty" on message board
        **/
    }
    //test
    void checkValue() {
    
        tempTime += Time.deltaTime;

        if (tempTime > 0.5f){
            
            print(bucketEmpty);
            tempTime = 0;
        }
    }
}
