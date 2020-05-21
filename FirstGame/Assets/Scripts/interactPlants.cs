using UnityEngine;

public class interactPlants : MonoBehaviour {

    private int timesPoured = 0;
    private bool bucketEmpty = false;
    public GameObject renderedWater;

    void Update() {
        

    }
    void pourWater() {

        timesPoured++;
        renderedWater.transform.Y;

        if(bucketEmpty) {

            timesPoured = 0;
            renderedWater.SetActive(false);
        }
    }
    void fillWater() {

        renderedWater.SetActive(true);
    }
}
