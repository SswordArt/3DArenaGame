using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camPos;
    void Update()
    {
        transform.position = camPos.transform.position;
    }

}
