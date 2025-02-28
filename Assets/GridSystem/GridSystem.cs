using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static GridSystem instance;

    [SerializeField] private float verticalLength; // X
    [SerializeField] private float horizontalLength; // Y

    [SerializeField] private float nodeEdgeLength;

    [SerializeField] private GameObject nodePrefab;

    private Vector3 upperLeftNodePosition;

    private Node[,] grid;
    private void Awake()
    {
        instance = this;

        CreateGrid();
    }

    public void CreateGrid()
    {
        int x = Mathf.FloorToInt(verticalLength / nodeEdgeLength); // x eksenindeki boyut
        int y = Mathf.FloorToInt(horizontalLength / nodeEdgeLength);// y eksenindeki boyut

        grid = new Node[x, y];

        Vector3 nodePosition = transform.position + new Vector3(-horizontalLength / 2 + nodeEdgeLength / 2, 0, verticalLength / 2 - nodeEdgeLength / 2);

        upperLeftNodePosition = nodePosition;

        for (int i = 0; i < x; i++) //x in verisini tutuyor
        {
            for (int j = 0; j < y; j++)//y in verisini tutuyor
            {
                GameObject nodeObject = Instantiate(nodePrefab, nodePosition, Quaternion.identity);

                nodeObject.transform.localScale = Vector3.one * nodeEdgeLength;

                Node tempNode = new Node(nodePosition, nodeObject);

                grid[i, j] = tempNode;

                nodePosition.x += nodeEdgeLength;
            }
            nodePosition.z -= nodeEdgeLength;
            nodePosition.x = upperLeftNodePosition.x;
        }
    }

    public Node GetNodeFromPosition(Vector3 position)
    {
        float differenceX = Mathf.Abs(position.z - upperLeftNodePosition.z);
        float differenceY = Mathf.Abs(position.x - upperLeftNodePosition.x);

        int x = Mathf.RoundToInt(differenceX / nodeEdgeLength);
        int y = Mathf.RoundToInt(differenceY / nodeEdgeLength);

        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(horizontalLength, 1, verticalLength));
    }
}

public class Node
{
    private bool isEmpty = true;
    private Vector3 position;
    private GameObject gameObject;

    public Node(Vector3 position, GameObject gameObject)
    {
        SetPosition(position);
        SetGameObject(gameObject);
    }

    public Vector3 GetPositon()
    {
        return position;
    }
    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public bool IsEmpty()
    {
        return isEmpty; 
    }

    public void SetEmpty(bool boolean)
    {
        this.isEmpty = boolean;
    }
}