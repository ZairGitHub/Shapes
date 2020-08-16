using UnityEngine;

public class EmitterDirection : MonoBehaviour
{
    private int xDirection;
    private int zDirection;

    public int GetXDirection()
    {
        if (name.Contains("Left"))
        {
            xDirection = 1;
        }
        else if (name.Contains("Right"))
        {
            xDirection = -1;
        }
        else
        {
            xDirection = Random.Range(-1, 2);
        }
        return xDirection;
    }

    public int GetZDirection()
    {
        if (name.Contains("Top"))
        {
            zDirection = -1;
        }
        else if (name.Contains("Bottom"))
        {
            zDirection = 1;
        }
        else
        {
            zDirection = Random.Range(-1, 2);
        }
        return zDirection;
    }
}
