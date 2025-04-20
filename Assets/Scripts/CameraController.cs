using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public bool freezeVertical;
    public bool freezeHorizontal;
    private Vector3 positionStore;

    public bool clampPosition;
    public Transform clampMin, clampMax;

    // Start is called before the first frame update
    void Start()
    {
        positionStore = transform.position;

        clampMin.SetParent(null);
        clampMax.SetParent(null);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        if(freezeVertical == true)
        {
            transform.position = new Vector3(transform.position.x, positionStore.y, transform.position.z);
        }

        if(freezeHorizontal == true)
        {
            transform.position = new Vector3(positionStore.x, transform.position.y, transform.position.z);
        }

        if (clampPosition == true)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, clampMin.position.x, clampMax.position.x),
                Mathf.Clamp(transform.position.y, clampMin.position.y, clampMax.position.y),
                transform.position.z);
        }
    }
}
