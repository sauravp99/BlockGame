using UnityEngine;

public class MatPropertyBlock : MonoBehaviour {

    public Color Color1, Color2;
    public float Speed = 1, Offset;
    private Renderer _renderer;
    public bool colorChange = false;
    private MaterialPropertyBlock _propBlock;
 
    void Awake() {

        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }
 
    void Update() {

        if (colorChange) {
            
            changeColor(); 
        }
    }
    
    void changeColor() {
        
        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);
        // Assign our new value.

        // Cycle color: Color.Lerp(Color1, Color2, (Mathf.Sin(Time.time * Speed + Offset) + 1) / 2f)
        _propBlock.SetColor("_Color", Color.blue);
        // Apply the edited values to the renderer.
        _renderer.SetPropertyBlock(_propBlock);
    }

}