using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }
}
