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

    private void Awake()
    {
        _boundaryGame = GameObject.FindWithTag(Tags.BoundaryGame);
        if (_boundaryGame != null)
        {
            _boundaryNorth = _boundaryGame.transform.GetChild(0).position;
            _boundaryEast = _boundaryGame.transform.GetChild(1).position;
            _boundarySouth = _boundaryGame.transform.GetChild(2).position;
            _boundaryWest = _boundaryGame.transform.GetChild(3).position;

            GameWidth = _boundaryEast.x - _boundaryWest.x;
            GameHeight = _boundaryNorth.y - _boundarySouth.y;
        }

        HalfGameWidth = GameWidth / 2.0f;
        HalfGameHeight = GameHeight / 2.0f;

        _boundaryView = GameObject.FindWithTag(Tags.BoundaryView);
        if (_boundaryView != null)
        {
            _boundaryNorth = _boundaryGame.transform.GetChild(0).position;
            _boundaryEast = _boundaryGame.transform.GetChild(1).position;
            _boundarySouth = _boundaryGame.transform.GetChild(2).position;
            _boundaryWest = _boundaryGame.transform.GetChild(3).position;

            ViewWidth = _boundaryEast.x - _boundaryWest.x;
            ViewHeight = _boundaryNorth.y - _boundarySouth.y;
        }
    }
}
