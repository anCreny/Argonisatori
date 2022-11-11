using UnityEngine;

public class SwitchOFF : MonoBehaviour
{
    public void TakeStatus(bool status)
    {
        status = !status;
        GetComponent<MeshRenderer>().enabled = status;
    }
}
