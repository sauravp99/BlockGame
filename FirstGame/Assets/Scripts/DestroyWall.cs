using UnityEngine;

public class DestroyWall : MonoBehaviour{

    public Rigidbody self;
    public PlayerMovement movement;
    // public Transfrom transfrom;
    // public Transfrom transform;
    public Vector3 obstSize; //Stores x, y, z values for obstacle
    public float pivotDistance;
    public Vector3 pivot;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        
        if(other.collider.tag == "Player"){
            
            // self.AddForce(0,0,-500); //When hit: pushes Player obj back 
            // movement.forwardForce = 0;
            gameObject.SetActive(false);
            obstSize = transform.localScale;
            // pieceL = obstSize.x / 3;
            // pieceH = obstSize.y / 3;
            // pieceW = obstSize.z / 3;
            obstSize.x = obstSize.x / 3;
            obstSize.y = obstSize.y / 5;
            obstSize.z = obstSize.z / 2;

            //We calculate each of the pivot distances for x, y and z
            //This is to prevent the pieces from spanning 
            float pivotDistX = obstSize.x*(obstSize.x * 3)/2; //We add the piece length with the number of pieces in a row
            float pivotDistY = obstSize.y*(obstSize.y * 5)/2;
            float pivotDistZ = obstSize.z*(obstSize.z * 2)/2;

            pivot = new Vector3(pivotDistX, pivotDistY, pivotDistZ);
            // print(obstSize);
            // breakIntoPieces();
            for(float x1 = 0; x1 <= obstSize.x * 3; x1++){
                for(float y1 = 0; y1 <= obstSize.y * 5; y1++){
                    for(float z1 = 0; z1 <= obstSize.z * 1; z1++){
                        print("Position: " + "x: " + x1 + " y: " + y1 + " z: " + z1);
                        // print("Piece length: " + pieceL + "Piece height: " + pieceH + "Piece width: " + pieceW);
                        breakIntoPieces(x1,y1,z1);
                    }
                }
            }
        }
    }
    void breakIntoPieces(float x, float y, float z){
        
        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(obstSize.x * x,obstSize.y * y,obstSize.z * z) - pivot;
        piece.transform.localScale = obstSize;
        // print(obstSize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().AddForce(0,0,300);
        piece.GetComponent<Rigidbody>().mass = 0;
    }
}
