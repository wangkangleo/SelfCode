using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform m_transform;

    //拖拽
    [Header("拖拽设置")]
    public float dragSpeed = 0.05f; // 拖拽移动速度，可根据需要调整
    public bool invertDrag = false; // 是否反转拖拽方向

    private Vector3 dragOrigin; // 鼠标按下时的初始位置（屏幕坐标）
    private bool isDragging = false; // 当前是否正在拖拽

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseDrag();
    }

    void HandleMouseDrag()
    {
        // 1. 检测鼠标左键按下（可改为右键或中键）
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
            return;
        }

        // 2. 如果鼠标左键抬起，结束拖拽
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // 3. 如果正在拖拽中，计算并移动摄像机
        if (!isDragging) return;

        // 计算当前帧鼠标位置与按下时的差值（屏幕像素差）
        Vector3 currentMousePos = Input.mousePosition;
        Vector3 screenDelta = dragOrigin - currentMousePos; // 注意这里用“原点-当前”，使拖动方向更符合直觉

        // 将屏幕像素差转换为世界空间的移动向量
        // 关键：根据摄像机当前的朝向（transform.right/forward）来构造移动方向
        Vector3 move = new Vector3(screenDelta.x, screenDelta.y, 0) * dragSpeed;

        // 将移动向量从“屏幕空间”旋转到“摄像机当前朝向的空间”
        // 假设你希望摄像机在XZ平面上移动（俯视角、策略游戏常见）
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0; // 通常我们只水平移动，锁定Y轴高度

        Camera.main.transform.position += move;

        // 应用移动（乘以Time.deltaTime保证帧率独立）
        //transform.Translate(move * Time.deltaTime, Space.World);

        // 更新原点，实现“持续拖动”而非“跳一下”
        dragOrigin = currentMousePos;
    }
}
