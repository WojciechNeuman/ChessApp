using UnityEngine;
 
public class Tile : MonoBehaviour {
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer tileRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject mark;
    public void Init(bool isOffset) {
        tileRenderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
    
    // TODO 
    // i want OnMouseEnter to work on a square that is occupied by a piece
    // also i want all the names of TILE changed to SQUARE xd
    
    public void Highlight()
    {
        highlight.SetActive(true);
    }
    public void Unhighlight()
    {
        highlight.SetActive(false);
    }

    public void Mark()
    {
        mark.SetActive(true);
    }
    public void Unmark()
    {
        mark.SetActive(false);
    }
}