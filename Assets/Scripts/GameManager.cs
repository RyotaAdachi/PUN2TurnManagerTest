using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class GameManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{

    [SerializeField] PunTurnManager turnManager = null;
    [SerializeField] Text playerNumberText;
    [SerializeField] Text turnText;
    [SerializeField] Text timeText;

    void Awake()
    {
        this.turnManager.TurnManagerListener = this;
    }

    void Start()
    {
        //StartTurn();
    }

    void Update()
    {
        playerNumberText.text = "Player="+PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        turnText.text = "Turn="+turnManager.Turn.ToString();
        timeText.text = "Time="+turnManager.RemainingSecondsInTurn.ToString();
    }

    public void OnTurnBegins(int turn)
    {
        if(turn % 2 == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            turnManager.SendMove(1, true);
        }
    }
    public void OnTurnCompleted(int turn)
    {
        Debug.Log("OnTurnCompleted");
        StartTurn();
    }
    public void OnPlayerMove(Player player, int turn, object move)
    {

    }
    public void OnPlayerFinished(Player player, int turn, object move)
    {

    }
    public void OnTurnTimeEnds(int turn)
    {
        Debug.Log("OnTurnTimeEnds");
        StartTurn();
    }

    public void StartTurn()//ターン開始メソッド（シーン開始時にRPCから呼ばれる呼ばれるようにしてあります。）
    {
        if (PhotonNetwork.IsMasterClient)
        {
            turnManager.BeginTurn();//turnmanagerに新しいターンを始めさせる
        }
    }

    public void EndMyTurn()
    {
        turnManager.SendMove(1, true);
    }
}
