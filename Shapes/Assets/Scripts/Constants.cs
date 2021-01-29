using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
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
        Vector3 boundaryEast = gameObject.transform.GetChild(1).position;
        Vector3 boundaryWest = gameObject.transform.GetChild(3).position;
        return boundaryEast.x - boundaryWest.x;
    }

    private float SetBoundaryHeight(GameObject gameObject)
    {
        Vector3 boundaryNorth = gameObject.transform.GetChild(0).position;
        Vector3 boundarySouth = gameObject.transform.GetChild(2).position;
        return boundaryNorth.y - boundarySouth.y;
    }
}
