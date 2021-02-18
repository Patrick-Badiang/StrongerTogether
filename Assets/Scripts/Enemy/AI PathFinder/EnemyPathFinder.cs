using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinder{

    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private AiGrid<PathNode> grid;

    private List<PathNode> openList;
    private List<PathNode> closedList;
    
    public EnemyPathFinder(int width, int height){
        grid = new AiGrid<PathNode>(width, height, 10f, Vector3.zero, (AiGrid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

//     private List<PathNode> FindPath(int startX, int startY, int endX, int endY){
//         PathNode startNode = grid.GetGridObject(startX, startY);
//         PathNode endNode = grid.GetGridObject(endX, endY);
        
//         openList = new List<PathNode>{ startNode};
//         closedList = new List<PathNode>();

//         for (int x = 0; x < grid.GetWidth(); x++){
//             for (int y=0; y < grid.GetHeight(); y++){
//                 PathNode pathNode = grid.GetGridObject(x , y);
//                 pathNode.gCost = int.MaxValue;
//                 pathNode.CalculatefCost();
//                 pathNode.cameFromNode = null;
//             }
//         }

//         //Complating the cost for our start node
//         startNode.gCost = 0;
//         startNode.hCost = CalculateDistanceCost(startNode, endNode);
//         startNode.CalculatefCost();

//         //cycle
//         while (openList.Count > 0){
//             PathNode currentNode = GetLowestFCostNode(openList);
//             if(currentNode == endNode){
//                 //Reached final Node
//                 return CalculatedPath(endNode);
//             }

//             openList.Remove(currentNode);
//             closedList.Add(currentNode);

//         }
//     }

//     //Function to get neighboring Nodes
//     private List<PathNode> GetNeighbourList(PathNode currentNode){
//         List<PathNode> neighbourList = new List<PathNode>();

//         if (currentNode.x - 1 >= 0) {
//             //left
//             neighbourList.Add(GetNode(currentNode.x - 1 , currentNode.y));
//             //left Down
//             if (currentNode.y -1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
//             //Left Up
//             if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y +1));
//         }
//         if (currentNode.x +1 < grid.GetWidth()){
//             //Right 
//             neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
//             //Right down
//             if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
//             //Right up
//             if(currentNode.y +1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1))
//         }

//         //down
//         if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y -1));
//         //up
//         if(currentNode.y +1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));

//         return neighbourList;
//     }

//     private List<PathNode> CalculatedPath(PathNode endNode){
//         return null;
//     }
    
//     private int CalculateDistanceCost( PathNode a, PathNode b){
//         int xDistance = Mathf.Abs(a.x - b.x);
//         int yDistance = Mathf.Abs(a.x - b.x);
//         int remaining = Mathf.Abs(xDistance - yDistance);
//         return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
//     }

//     private PathNode GetLowestFCostNode(List<PathNode> pathNodeList){
//         PathNode lowestFCostNode = pathNodeList[0];
//         for( int i=1; i < pathNodeList.Count; i++){
//             if(pathNodeList[i].fCost < lowestFCostNode.fCost){
//                 lowestFCostNode = pathNodeList[i];
//             }
//         }
//         return lowestFCostNode;
//     }
}
