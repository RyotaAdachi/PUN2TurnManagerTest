using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class GameManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{

    [SerializeField] PunTurnManager turnManager;
    [SerializeField] float time;

    void Awake()
    {
        this.turnManager.TurnManagerListener = this;
    }

    void Start()
    {
        StartTurn();
    }

    void Update()
    {
        time = turnManager.RemainingSecondsInTurn;
    }

    public void OnTurnBegins(int turn)
    {

    }
    public void OnTurnCompleted(int turn)
    {

    }
    public void OnPlayerMove(Player player, int turn, object move)
    {

    }
    public void OnPlayerFinished(Player player, int turn, object move)
    {

    }
    public void OnTurnTimeEnds(int turn)
    {

    }

    public void StartTurn()//ターン開始メソッド（シーン開始時にRPCから呼ばれる呼ばれるようにしてあります。）
    {
        if (PhotonNetwork.IsMasterClient)
        {
            this.turnManager.BeginTurn();//turnmanagerに新しいターンを始めさせる
        }
    }
}
