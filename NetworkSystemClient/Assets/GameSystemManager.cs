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
    GameObject turnOrder;
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
            else if (go.name == "TurnOrder")
                turnOrder = go;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Message1 + "");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Message2 + "");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Message3 + "");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Message4 + "");
        }
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
        //tl.GetComponent<Button>().image.sprite = playerShape[0];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }

    private void TopMiddlePressed()
    {
        //tm.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }

    private void TopRightPressed()
    {
       // tr.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }

    private void MiddleLeftPressed()
    {
        //ml.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }

    private void MiddleMiddlePressed()
    {
       // mm.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }

    private void MiddleRightPressed()
    {
       // mr.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }
    private void BottomLeftPressed()
    {
       // bl.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);

    }
    private void BottomMiddlePressed()
    {
        //bm.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);
    }
    private void BottomRightPressed()
    {
        //br.GetComponent<Button>().image.sprite = playerShape[];
        
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        ChangeGameState(5);

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
        turnOrder.SetActive(false);
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
            turnOrder.SetActive(true);
            turnOrder.GetComponent<Text>().text = "Your Turn";
            if (tl.GetComponent<Button>().image.sprite == null)
                tl.GetComponent<Button>().interactable = true;
            if (tm.GetComponent<Button>().image.sprite == null)
                tm.GetComponent<Button>().interactable = true;
            if (tr.GetComponent<Button>().image.sprite == null)
                tr.GetComponent<Button>().interactable = true;
            if (ml.GetComponent<Button>().image.sprite == null)
                ml.GetComponent<Button>().interactable = true;
            if (mm.GetComponent<Button>().image.sprite == null)
                mm.GetComponent<Button>().interactable = true;
            if (mr.GetComponent<Button>().image.sprite == null)
                mr.GetComponent<Button>().interactable = true;
            if (bl.GetComponent<Button>().image.sprite == null)
                bl.GetComponent<Button>().interactable = true;
            if (bm.GetComponent<Button>().image.sprite == null)
                bm.GetComponent<Button>().interactable = true;
            if (br.GetComponent<Button>().image.sprite == null)
                br.GetComponent<Button>().interactable = true;
        }
        else if (newState == GameStates.WaitingForTurn)
        {
            //if ()
            gamePanel.SetActive(true);
            turnOrder.SetActive(true);
            turnOrder.GetComponent<Text>().text = "Your Oppenent's Turn";

            tl.GetComponent<Button>().interactable = false;
            tm.GetComponent<Button>().interactable = false;
            tr.GetComponent<Button>().interactable = false;
            ml.GetComponent<Button>().interactable = false;
            mm.GetComponent<Button>().interactable = false;
            mr.GetComponent<Button>().interactable = false;
            bl.GetComponent<Button>().interactable = false;
            bm.GetComponent<Button>().interactable = false;
            br.GetComponent<Button>().interactable = false;
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
