using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollws : MonoBehaviour
{

    [SerializeField] private Transform target; // 绑定 Player
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // 摄像机偏移
    [SerializeField] private float smoothSpeed = 0.1f; // 平滑速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // 仅跟随位置，忽略旋转
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
