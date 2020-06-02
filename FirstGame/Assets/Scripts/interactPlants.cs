using UnityEngine;

public class interactPlants : MonoBehaviour {

    private int timesPoured = 0;
    public bool bucketEmpty = true;
    public GameObject renderedWater;
    public Transform defaultWaterSpawn;
    private float timePassed;
    private int timer = 0;

    void Update() {
        
        if (bucketEmpty == false) {
            
            decreaseWaterLevel();
        }
    }

    // private void FixedUpdate() {

    //     decreaseWaterLevel();   
    // }

    void decreaseWaterLevel() { //Moves renderedWater -0.015f down Y axis every sec
        
        timePassed += Time.deltaTime;
        
        if (timePassed > 1) { 
            
            print(timer++); //todo: stop timer after bucketEmpty -> true
            timePassed -= 1;
            decrease();

            if (timer == 30) {

                emptyBucket();
            }
        }
    }

    void decrease() {

        renderedWater.transform.position = renderedWater.transform.position + new Vector3(0,-0.015f,0);
    }

    public void pourWater() {

        timesPoured++;
        decrease();

        if (timesPoured == 6) {

            emptyBucket();
        }
    }

    void fillWater() {

        //todo: Fill water from container 
        renderedWater.SetActive(true);
        renderedWater.transform.position = defaultWaterSpawn.position;
        bucketEmpty = false;
    }

    void emptyBucket() {

        bucketEmpty = true;
        renderedWater.SetActive(false);
        /**todo:
            switch animation to stop water pouring from bucket hole
        **/
    }
}
