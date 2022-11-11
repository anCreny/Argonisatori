using UnityEngine;

public class ViewBugFix : MonoBehaviour
{
    private int _counter;
    
    private int Counter
    {
        get => _counter;
        set
        {
            if (_counter < 5)
            {
                _counter++;
            }
        }
    }

    private void Update()
    {
        if (_counter == 5)
        {
            GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        Counter = 1;
    }
}
