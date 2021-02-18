using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class AiGrid<TGridObject>
{
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellsize;
    private Vector3 originPosition;

    private TGridObject [,] gridArray;  //Defines a "multi-dimensional" array with two dimensions
    private TextMesh[,] debugTextArray;

    public AiGrid(int width, int height, float cellsize, Vector3 originPosition, Func<AiGrid<TGridObject>, int, int, TGridObject > createGridObject){
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        debugTextArray = new TextMesh[width, height];
        
        
        for (int x=0; x<gridArray.GetLength(0); x++){
            for (int y=0; y<gridArray.GetLength(1); y++){
                 gridArray[x,y] = createGridObject(this, x, y);

            }
        }

        bool showDebug = false;
        if(showDebug)
        {
                TextMesh[,] debugTextArray = new TextMesh[width, height];
        //Cycling through a multi-dimensional array
            for (int x=0; x<gridArray.GetLength(0); x++)
            {
             for (int y=0; y<gridArray.GetLength(1); y++)
             {
                 
                  //Places a text object at every position and puts it in the center
                  debugTextArray[x,y] =UtilsClass.CreateWorldText(gridArray[x, y].ToString(),null, GetWorldPosition(x , y) + new Vector3(cellsize, cellsize) * 0.5f, 30, Color.white, TextAnchor.MiddleCenter);  
                 
                  Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                  Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);

              }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f); //Draws at the top of the graph
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f); //Draws the vertical lines at the end of the graph
        
            OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>{
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }   
    }

    public int GetWidth(){
        return width;
    }

    public int GetHeight(){
        return height;
    }

    public float GetCellSize(){
        return cellsize;
    }

    //Converts Grid position into World
    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x,y) * cellsize + originPosition;
    }

    //We need a function to get the x and y when given a certain vector3 for the world position
    //Converts World position into Grid position
    private void GetXY(Vector3 worldPosition, out int x, out int y){
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellsize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellsize);

    }

    public void SetGridObject(int x, int y, TGridObject value){
      
        //How should the class deal with invalid values? Ex: negative numbers. 
        //What could happen: throw and error(Breaks the game), Correct to the closest value(Weird stuff happens at the edges), or ignore it(best one for ours)
    
        if( x>=0 && y >= 0 && x < width && y < height){
            gridArray[x,y]  = value; 
            debugTextArray[x,y].text = gridArray[x,y].ToString();
        }
    }

    //A version to set the value but instead weare receiving theworld position
    public void SetGridObject(Vector3 worldPosition, TGridObject value){
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x,y,value);
    }

    public TGridObject GetGridObject(int x, int y){
        if( x>=0 && y >= 0 && x < width && y < height){
            return gridArray[x,y];
        }else{
            return default(TGridObject); 
            //if the grid is a bool then it returns a bool. if object is an int it will return a int. etc
        }
    }

    public TGridObject GetGridObject(Vector3 worldPosition){
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }
}
