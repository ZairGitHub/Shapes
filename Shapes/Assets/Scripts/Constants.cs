using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private GameObject _boundary;
    private Transform _boundaryNorth;
    private Transform _boundaryEast;
    private Transform _boundarySouth;
    private Transform _boundaryWest;

    public float HalfBoundaryWidth { get; private set; }

    public float HalfBoundaryHeight { get; private set; }

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

            HalfBoundaryWidth = _boundaryEast.transform.position.x;
            HalfBoundaryHeight = _boundaryNorth.transform.position.y;

            Debug.Log($"FullWidth: {FullBoundaryWidth}, FullHeight: {FullBoundaryHeight}, " +
                $"BoundaryWidth {HalfBoundaryWidth}, BoundaryHeight {HalfBoundaryHeight}");
        }

        GameWidth = HalfBoundaryWidth * 2;
        GameHeight = HalfBoundaryHeight * 2;
    }
}
