using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTocToe : MonoBehaviour
{
    [SerializeField] Square squarePrefab;
    [SerializeField] Transform panel;
    List<Square> squares = new List<Square>();
    List<Square[]> lines = new List<Square[]>();

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            Square square = Instantiate(squarePrefab, Vector3.zero, Quaternion.identity, panel);
            square.ClickAction = SelectSquare;
            squares.Add(square);
        }

        lines.Add(new Square[] {squares[0], squares[1], squares[2]});
        lines.Add(new Square[] {squares[3], squares[4], squares[5]});
        lines.Add(new Square[] {squares[6], squares[7], squares[8]});
        lines.Add(new Square[] {squares[0], squares[3], squares[6]});
        lines.Add(new Square[] {squares[1], squares[4], squares[7]});
        lines.Add(new Square[] {squares[2], squares[5], squares[8]});
        lines.Add(new Square[] {squares[0], squares[4], squares[8]});
        lines.Add(new Square[] {squares[2], squares[4], squares[6]});
    }

    void SelectSquare(Square square)
    {
        Debug.Log("SelectSquare");
        square.ChangeMark(Square.Marks.Circle);

        if(IsGameEnd())
        {
            // Game End
        }
        
    }

    bool IsGameEnd()
    {
        foreach(Square[] s in lines)
        {
            if(s[0].GetMark() != Square.Marks.None)
            {
                if(s[0].GetMark() == s[1].GetMark() && s[0].GetMark() == s[2].GetMark())
                {
                    Debug.Log("Game End!");
                    return true;
                }
            }
        }
        
        return false;
    }

}
