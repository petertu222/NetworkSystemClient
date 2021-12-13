using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour
{
    GameObject inputFieldUsername, inputFieldPassword, buttonSubmit, toggleLogin, toggleCreate;

    GameObject networkedClient;

    GameObject findGameSessionButton, placeHolderGameButton, observeButton;
    GameObject gamePanel;
    GameObject tl, tm, tr, ml, mm, mr, bl, bm, br;
    public Sprite[] playerShape;//0=x ,1=o
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.name == "InputFieldUsername")
                inputFieldUsername = go;
            else if (go.name == "InputFieldPassword")
                inputFieldPassword = go;
            else if (go.name == "ButtonSubmit")
                buttonSubmit = go;
            else if (go.name == "ToggleLogin")
                toggleLogin = go;
            else if (go.name == "ToggleCreate")
                toggleCreate = go;
            else if (go.name == "NetworkedClient")
                networkedClient = go;
            if (go.name == "FindGameSessionButton")
                findGameSessionButton = go;
            else if (go.name == "PlaceHolderGameButton")
                placeHolderGameButton = go;
            else if (go.name == "ObserverButton")
                observeButton = go;
            else if (go.name == "GamePanel")
                gamePanel = go;
            else if (go.name == "TL")
                tl = go;
            else if (go.name == "TM")
                tm = go;
            else if (go.name == "TR")
                tr = go;
            else if (go.name == "ML")
                ml = go;
            else if (go.name == "MM")
                mm = go;
            else if (go.name == "MR")
                mr = go;
            else if (go.name == "BL")
                bl = go;
            else if (go.name == "BM")
                bm = go;
            else if (go.name == "BR")
                br = go;
        }

        buttonSubmit.GetComponent<Button>().onClick.AddListener(SubmitButtonPressed);
        toggleCreate.GetComponent<Toggle>().onValueChanged.AddListener(ToggleCreateValueChanged);
        toggleLogin.GetComponent<Toggle>().onValueChanged.AddListener(ToggleLoginValueChanged);

        //inputFieldUsername.GetComponent<InputField>().onEndEdit.AddListener()
        findGameSessionButton.GetComponent<Button>().onClick.AddListener(FindGameSessionButtonPressed);
        observeButton.GetComponent<Button>().onClick.AddListener(ObserverButtonPressed);

        tl.GetComponent<Button>().onClick.AddListener(TopLeftPressed);
        tm.GetComponent<Button>().onClick.AddListener(TopMiddlePressed);
        tr.GetComponent<Button>().onClick.AddListener(TopRightPressed);
        ml.GetComponent<Button>().onClick.AddListener(MiddleLeftPressed);
        mm.GetComponent<Button>().onClick.AddListener(MiddleMiddlePressed);
        mr.GetComponent<Button>().onClick.AddListener(MiddleRightPressed);
        bl.GetComponent<Button>().onClick.AddListener(BottomLeftPressed);
        bm.GetComponent<Button>().onClick.AddListener(BottomMiddlePressed);
        br.GetComponent<Button>().onClick.AddListener(BottomRightPressed);

        placeHolderGameButton.GetComponent<Button>().onClick.AddListener(PlaceHolderGameButtonPressed);
        inputFieldUsername.SetActive(false);
        inputFieldPassword.SetActive(false);
        buttonSubmit.SetActive(false);
        toggleLogin.SetActive(false);
        toggleCreate.SetActive(false);
        gamePanel.SetActive(false);
        placeHolderGameButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    ChangeGameState(GameStates.Login);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    ChangeGameState(GameStates.MainMenu);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    ChangeGameState(GameStates.WaitingForMatch);
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    ChangeGameState(GameStates.PlayingTicTacToe);
        //}
    }

    public void SubmitButtonPressed()
    {
        string n = inputFieldUsername.GetComponent<InputField>().text;
        string p = inputFieldUsername.GetComponent<InputField>().text;

        if (toggleLogin.GetComponent<Toggle>().isOn)
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Login + "," + n + "," + p);
        else
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.CreateAccount + "," + n + "," + p);
    }
    private void ToggleCreateValueChanged(bool newValue)
    {
        toggleCreate.GetComponent<Toggle>().SetIsOnWithoutNotify(!newValue);
    }
    private void ToggleLoginValueChanged(bool newValue)
    {
        toggleLogin.GetComponent<Toggle>().SetIsOnWithoutNotify(!newValue);

    }
    private void FindGameSessionButtonPressed()
    {
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.AddToGameSessionQueue + "");
        ChangeGameState(GameStates.WaitingForMatch);
    }

    private void PlaceHolderGameButtonPressed()
    {
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }
    private void ObserverButtonPressed()
    {
        
    }
    private void TopLeftPressed()
    {
        //tl.GetComponent<Button>().image.sprite = playerShape[];
        tl.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }

    private void TopMiddlePressed()
    {
        //tm.GetComponent<Button>().image.sprite = playerShape[];
        tm.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }

    private void TopRightPressed()
    {
       // tr.GetComponent<Button>().image.sprite = playerShape[];
        tr.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }

    private void MiddleLeftPressed()
    {
        //ml.GetComponent<Button>().image.sprite = playerShape[];
        ml.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }

    private void MiddleMiddlePressed()
    {
       // mm.GetComponent<Button>().image.sprite = playerShape[];
        mm.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }

    private void MiddleRightPressed()
    {
       // mr.GetComponent<Button>().image.sprite = playerShape[];
        mr.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
    }
    private void BottomLeftPressed()
    {
       // bl.GetComponent<Button>().image.sprite = playerShape[];
        bl.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");

    }
    private void BottomMiddlePressed()
    {
        //bm.GetComponent<Button>().image.sprite = playerShape[];
        bm.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");

    }
    private void BottomRightPressed()
    {
        //br.GetComponent<Button>().image.sprite = playerShape[];
        br.GetComponent<Button>().interactable = false;
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");

    }

    public void ChangeGameState(int newState)
    {
        Debug.Log("States" + newState);
        inputFieldUsername.SetActive(false);
        inputFieldPassword.SetActive(false);
        buttonSubmit.SetActive(false);
        toggleLogin.SetActive(false);
        toggleCreate.SetActive(false);
        findGameSessionButton.SetActive(false);
        placeHolderGameButton.SetActive(false);
        observeButton.SetActive(false);
        gamePanel.SetActive(false);

        if (newState == GameStates.Login)
        {
            inputFieldUsername.SetActive(false);
            inputFieldPassword.SetActive(false);
            buttonSubmit.SetActive(false);
            toggleLogin.SetActive(false);
            toggleCreate.SetActive(false);
            gamePanel.SetActive(false);

        }
        else if (newState == GameStates.MainMenu)
        {
            findGameSessionButton.SetActive(true);
            observeButton.SetActive(true);
            gamePanel.SetActive(false);
        }
        else if (newState == GameStates.WaitingForMatch)
        {

        }
        else if (newState == GameStates.PlayingTicTacToe)
        {
            
            //placeHolderGameButton.SetActive(true);
            gamePanel.SetActive(true);

        }
        else if (newState == GameStates.WaitingForTurn)
        {

        }
    }
}

public static class GameStates
{
    public const int Login = 1;

    public const int MainMenu = 2;

    public const int WaitingForMatch = 3;

    public const int PlayingTicTacToe = 4;

    public const int WaitingForTurn = 5;
}
