using UnityEngine;

public class SwitchON : MonoBehaviour
{
    public void TakeStatus(bool status)
    {
        GetComponent<MeshRenderer>().enabled = status;
    }
}
