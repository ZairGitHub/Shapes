using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private GameObject _boundary;
    private GameObject _boundaryNorth;
    private GameObject _boundaryEast;
    private GameObject _boundarySouth;
    private GameObject _boundaryWest;

    public float BoundaryWidth { get; private set; }

    public float BoundaryHeight { get; private set; }

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    private void Awake()
    {
        _boundary = GameObject.FindWithTag(Tags.Boundary);
        if (_boundary != null)
        {
            _boundaryNorth = _boundary.transform.GetChild(0).gameObject;
            _boundaryEast = _boundary.transform.GetChild(1).gameObject;
            _boundarySouth = _boundary.transform.GetChild(2).gameObject;
            _boundaryWest = _boundary.transform.GetChild(3).gameObject;

            BoundaryWidth = _boundaryEast.transform.position.x;
            BoundaryHeight = _boundaryNorth.transform.position.y;
        }

        GameWidth = BoundaryWidth * 2;
        GameHeight = BoundaryHeight * 2;
    }
}
