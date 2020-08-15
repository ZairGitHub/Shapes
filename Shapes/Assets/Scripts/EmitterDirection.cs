using UnityEngine;

public class EmitterDirection : MonoBehaviour
{
    private int xDirection;
    private int zDirection;

    private void Start()
    {
        switch (name)
        {
            case string a when a.Contains("TopLeft"):
                xDirection = 1;
                zDirection = -1;
                break;

            case string a when a.Contains("TopMiddle"):
                xDirection = Random.Range(-1, 1);
                zDirection = -1;
                break;

            case string a when a.Contains("TopRight"):
                xDirection = -1;
                zDirection = -1;
                break;

            case string a when a.Contains("MiddleLeft"):
                xDirection = 1;
                zDirection = Random.Range(-1, 1);
                break;

            case string a when a.Contains("MiddleRight"):
                xDirection = -1;
                zDirection = Random.Range(-1, 1);
                break;

            case string a when a.Contains("BottomLeft"):
                xDirection = 1;
                zDirection = 1;
                break;

            case string a when a.Contains("BottomMiddle"):
                xDirection = Random.Range(-1, 1);
                zDirection = 1;
                break;

            case string a when a.Contains("BottomRight"):
                xDirection = -1;
                zDirection = 1;
                break;
        }
    }

    public int GetXDirection()
    {
        return xDirection;
    }

    public int GetZDirection()
    {
        return zDirection;
    }
}
