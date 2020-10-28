using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] TicTocToe game;
    [SerializeField] int turn;
    [SerializeField] Text statusText = null;


    void Start()
    {
        game.SelectedAction = EndPlayerTurn;
        StartGame();
        Show();
    }

    void Show()
    {
        if (turn % 2 == 0)
        {
            statusText.text = "○の番";
        }
        else
        {
            statusText.text = "×の番";
        }
    }

    void StartGame()
    {
        game.GenerateBoard();
        turn = 0;
    }

    void EndPlayerTurn()
    {
        Debug.Log("EndPlayerTurn");

        // 相手プレイヤーがランダムにカードを選択
        List<Square> selectableSquares = game.GetSquares().FindAll(x => x.GetMark() == Square.Marks.None);
        Debug.Log(selectableSquares.Count);
        int r = Random.Range(0, selectableSquares.Count);
        selectableSquares[r].ChangeMark(Square.Marks.Cross);
        
        // ゲームが終了したかどうかチェック
        if(game.IsGameEnd())
        {
            Debug.Log("GameEnd");
            return;
        }

        turn++;
        Show();
    }

    public void RestartGame()
    {
        turn = 0;
        foreach(Square square in game.GetSquares())
        {
            square.ChangeMark(Square.Marks.None);
        }
    }

}
