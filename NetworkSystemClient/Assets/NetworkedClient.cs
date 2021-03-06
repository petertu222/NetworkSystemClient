using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedClient : MonoBehaviour
{

    int connectionID;
    int maxConnections = 1000;
    int reliableChannelID;
    int unreliableChannelID;
    int hostID;
    int socketPort = 5491;
    byte error;
    bool isConnected = false;
    int ourClientID;

    GameObject gameSystemManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.name == "GameSystemManager")
            {
                gameSystemManager = go;

            }

        }
            Connect();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.S))
        //    SendMessageToHost("Hello from client");

        UpdateNetworkConnection();
    }

    private void UpdateNetworkConnection()
    {
        if (isConnected)
        {
            int recHostID;
            int recConnectionID;
            int recChannelID;
            byte[] recBuffer = new byte[1024];
            int bufferSize = 1024;
            int dataSize;
            NetworkEventType recNetworkEvent = NetworkTransport.Receive(out recHostID, out recConnectionID, out recChannelID, recBuffer, bufferSize, out dataSize, out error);

            switch (recNetworkEvent)
            {
                case NetworkEventType.ConnectEvent:
                    Debug.Log("connected.  " + recConnectionID);
                    ourClientID = recConnectionID;
                    break;
                case NetworkEventType.DataEvent:
                    string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                    ProcessRecievedMsg(msg, recConnectionID);
                    //Debug.Log("got msg = " + msg);
                    break;
                case NetworkEventType.DisconnectEvent:
                    isConnected = false;
                    Debug.Log("disconnected.  " + recConnectionID);
                    break;
            }
        }
    }
    
    private void Connect()
    {

        if (!isConnected)
        {
            Debug.Log("Attempting to create connection");

            NetworkTransport.Init();

            ConnectionConfig config = new ConnectionConfig();
            reliableChannelID = config.AddChannel(QosType.Reliable);
            unreliableChannelID = config.AddChannel(QosType.Unreliable);
            HostTopology topology = new HostTopology(config, maxConnections);
            hostID = NetworkTransport.AddHost(topology, 0);
            Debug.Log("Socket open.  Host ID = " + hostID);

            connectionID = NetworkTransport.Connect(hostID, "192.168.2.228", socketPort, 0, out error); // server is local on network

            if (error == 0)
            {
                isConnected = true;

                Debug.Log("Connected, id = " + connectionID);

            }
        }
    }
    
    public void Disconnect()
    {
        NetworkTransport.Disconnect(hostID, connectionID, out error);
    }
    
    public void SendMessageToHost(string msg)
    {
        byte[] buffer = Encoding.Unicode.GetBytes(msg);
        NetworkTransport.Send(hostID, connectionID, reliableChannelID, buffer, msg.Length * sizeof(char), out error);
    }

    private void ProcessRecievedMsg(string msg, int id)
    {
        Debug.Log("msg recieved = " + msg + ".  connection id = " + id);

        string[] csv = msg.Split(',');

        int signifier = int.Parse(csv[0]);

        if (signifier == ServerToClientSignifiers.LoginResponse)
        {
            int loginResultSiginifer = int.Parse(csv[1]);

            if (loginResultSiginifer == LoginResponses.Success)
                gameSystemManager.GetComponent<GameSystemManager>().ChangeGameState(GameStates.MainMenu);
        }
        //else if (signifier == ServerToClientSignifiers.GameSeesionStarted)
        //{
        //    Debug.Log("you are id" + id);
        //    gameSystemManager.GetComponent<GameSystemManager>().ChangeGameState(GameStates.WaitingForTurn);
        //}
        else if (signifier == ServerToClientSignifiers.GameSeesionStarted)
        {
            gameSystemManager.GetComponent<GameSystemManager>().ChangeGameState(GameStates.PlayingTicTacToe);
        }
        else if (signifier == ServerToClientSignifiers.OpponentTicTacToePlay)
        {
            Debug.Log("Your turn!");
            gameSystemManager.GetComponent<GameSystemManager>().ChangeGameState(GameStates.PlayingTicTacToe);
            //gameSystemManager.GetComponent<GameSystemManager>().ChangeGameState(GameStates.WaitingForTurn);
        }
        else if (signifier == ServerToClientSignifiers.MessageResponse1)
        {
            Debug.Log("Hello");
        }
        else if (signifier == ServerToClientSignifiers.MessageResponse2)
        {
            Debug.Log("Bye");
        }
        else if (signifier == ServerToClientSignifiers.MessageResponse3)
        {
            Debug.Log("Nice");
        }
        else if (signifier == ServerToClientSignifiers.MessageResponse4)
        {
            Debug.Log("Oh No");
        }


    }

    public bool IsConnected()
    {
        return isConnected;
    }


}
public static class ClientToServerSignifiers
{
    public const int Login = 1;
    public const int CreateAccount = 2;
    public const int AddToGameSessionQueue = 3;
    public const int TicTacToePlay = 4;
    public const int Message1 = 5;
    public const int Message2 = 6;
    public const int Message3 = 7;
    public const int Message4 = 8;
}

public static class ServerToClientSignifiers
{
    public const int LoginResponse = 1;
    public const int GameSeesionStarted = 2;
    public const int OpponentTicTacToePlay = 3;
    public const int WaitingForTurn = 4;
    public const int MessageResponse1 = 5;
    public const int MessageResponse2 = 6;
    public const int MessageResponse3 = 7;
    public const int MessageResponse4 = 8;

    //public const int LoginFailure = 2;

    //public const int CreateAccountSuccess = 1;
    //public const int CreateAccountFailure = 2;
}

public static class LoginResponses
{
    public const int Success = 1;

    public const int FailureNameInUse = 2;

    public const int FailureNameNotFound = 3;

    public const int FailureNameIncorrectPassword = 4;
}