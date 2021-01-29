using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private Vector3 _boundaryNorth;
    private Vector3 _boundaryEast;
    private Vector3 _boundarySouth;
    private Vector3 _boundaryWest;
    private GameObject _boundaryGame;
    private GameObject _boundaryView;

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    public float HalfGameWidth { get; private set; }

    public float HalfGameHeight { get; private set; }

    public float ViewWidth { get; private set; }

    public float ViewHeight { get; private set; }

    public float HalfViewWidth { get; private set; }

    public float HalfViewHeight { get; private set; }

    private void Awake()
    {
        _boundaryGame = GameObject.FindWithTag(Tags.BoundaryGame);
        if (_boundaryGame != null)
        {
            GameWidth = SetBoundaryWidth(_boundaryGame);
            GameHeight = SetBoundaryHeight(_boundaryGame);
        }

        HalfGameWidth = GameWidth / 2.0f;
        HalfGameHeight = GameHeight / 2.0f;

        _boundaryView = GameObject.FindWithTag(Tags.BoundaryView);
        if (_boundaryView != null)
        {
            ViewWidth = SetBoundaryWidth(_boundaryView);
            ViewHeight = SetBoundaryHeight(_boundaryView);
        }

        HalfViewWidth = ViewWidth / 2.0f;
        HalfViewHeight = ViewHeight / 2.0f;
    }

    private float SetBoundaryWidth(GameObject gameObject)
    {
        if (gameObject != null)
        {
            _boundaryEast = gameObject.transform.GetChild(1).position;
            _boundaryWest = gameObject.transform.GetChild(3).position;
            return _boundaryEast.x - _boundaryWest.x;
        }
        return 0.0f;
    }

    private float SetBoundaryHeight(GameObject gameObject)
    {
        if (gameObject != null)
        {
            _boundaryNorth = gameObject.transform.GetChild(0).position;
            _boundarySouth = gameObject.transform.GetChild(2).position;
            return _boundaryNorth.y - _boundarySouth.y;
        }
        return 0.0f;
    }
}
