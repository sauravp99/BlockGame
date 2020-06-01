using UnityEngine;

public class interactPlants : MonoBehaviour {

    private int timesPoured = 0;
    // private bool bucketEmpty = false;
    public GameObject renderedWater;
    private float timer;

    void Update() {
        
    }
    private void FixedUpdate() {

        renderedWater.SetActive(true);
        timer += Time.deltaTime;
        
        if(timer > 1) { 
             
            timer -= 1;

         renderedWater.transform.position = renderedWater.transform.position + new Vector3(0,-0.05f,0);
        }    
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
