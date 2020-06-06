using UnityEngine;

public class MatPropertyBlock : MonoBehaviour {

    public Color Color1;
    public float Speed = 1, Offset;
    private Renderer _renderer;
    public bool colorChange = false;
    private MaterialPropertyBlock _propBlock;
 
    void Start() {

        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }
 
    void Update() {

        if (colorChange) {
            
            changeColor(); 
        }
    }
    
    public void changeColor() {
        
        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);
        // Assign our new value.

        // Cycle color: Color.Lerp(Color.green, Color2, (Mathf.Sin(Time.time * Speed + Offset) + 1) / 2f)
        _propBlock.SetColor("_Color", Color.green);
        // Apply the edited values to the renderer.
        _renderer.SetPropertyBlock(_propBlock);
    }

    public void revertColor() {

        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", Color.grey);
        _renderer.SetPropertyBlock(_propBlock);

    }

}