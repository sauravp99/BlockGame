using UnityEngine;

public class interactPlants : MonoBehaviour {

    private int timesPoured = 0;
    // private bool bucketEmpty = false;
    public GameObject renderedWater;

    void Update() {
        

    }
    public void pourWater() {
        
        renderedWater.SetActive(true);
        timesPoured++;
        renderedWater.transform.position = renderedWater.transform.position + new Vector3(0,-0.05f,0);

        if(timesPoured == 3) {
            
            emptyBucket();
        }
    }
    void fillWater() {

        renderedWater.SetActive(true);
    }
    void emptyBucket() {
    
            timesPoured = 0;
            renderedWater.SetActive(false);
        }
    }
