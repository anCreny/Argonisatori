using UnityEngine;

public class ChangeEmission : MonoBehaviour
{
    public void TakeEmissionStatus(bool status)
    {
        if (status)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }
}
