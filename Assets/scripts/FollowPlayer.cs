using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject ObjectToFollow;
    private Vector3 offset = new Vector3(0,15,-15);
    // Start is called before the first frame update

    public void SwitchObject(GameObject character, float camSize)
    {
        ObjectToFollow=character;
        transform.position = ObjectToFollow.transform.position+offset;
        transform.LookAt(ObjectToFollow.transform.position);
        Camera cameraComponent = GetComponent<Camera>();
        cameraComponent.orthographicSize = camSize;

    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectToFollow!=null){
            transform.position = ObjectToFollow.transform.position+offset;
        }
    }
}