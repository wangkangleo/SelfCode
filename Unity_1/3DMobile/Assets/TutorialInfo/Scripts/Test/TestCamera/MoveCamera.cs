using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_transform)
        {
            Vector3 postion = transform.position;
            postion.z -= 0.1f;
            m_transform.SetPositionAndRotation(postion, transform.rotation);

            var rotaion = transform.rotation;
        }
    }
}
