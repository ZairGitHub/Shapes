using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private GameObject _boundary;
    private Transform _boundaryNorth;
    private Transform _boundaryEast;
    private Transform _boundarySouth;
    private Transform _boundaryWest;

    public float BoundaryWidth { get; private set; }

    public float BoundaryHeight { get; private set; }

    public float FullBoundaryWidth { get; private set; }

    public float FullBoundaryHeight { get; private set; }

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    private void Awake()
    {
        _boundary = GameObject.FindWithTag(Tags.Boundary);
        if (_boundary != null)
        {
            _boundaryNorth = _boundary.transform.GetChild(0);
            _boundaryEast = _boundary.transform.GetChild(1);
            _boundarySouth = _boundary.transform.GetChild(2);
            _boundaryWest = _boundary.transform.GetChild(3);

            FullBoundaryWidth = _boundaryEast.position.x - _boundaryWest.position.x;
            FullBoundaryHeight = _boundaryNorth.position.y - _boundarySouth.position.y;

            BoundaryWidth = _boundaryEast.transform.position.x;
            BoundaryHeight = _boundaryNorth.transform.position.y;

            Debug.Log($"FullWidth: {FullBoundaryWidth}, FullHeight: {FullBoundaryHeight}, " +
                $"BoundaryWidth {BoundaryWidth}, BoundaryHeight {BoundaryHeight}");
        }

        GameWidth = BoundaryWidth * 2;
        GameHeight = BoundaryHeight * 2;
    }
}
