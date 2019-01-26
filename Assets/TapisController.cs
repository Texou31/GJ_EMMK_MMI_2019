using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisController : MonoBehaviour
{
    private bool isHold;
    private GameObject holder;

    // Start is called before the first frame update
    void Start()
    {
        isHold = false;
        holder = null;
    }

    public void Interact(GameObject newHolder)
    {
        if (!isHold)
        {
            SetNewHolder(newHolder);
            return;
        }

        if(newHolder == holder)
        {
            UnsetHolder();
        }
    }

    private void SetNewHolder(GameObject newHolder)
    {
        isHold = true;
        holder = newHolder;

        transform.SetParent(holder.transform);
    }

    private void UnsetHolder()
    {
        isHold = false;
        holder = null;

        transform.SetParent(null);
    }
}
