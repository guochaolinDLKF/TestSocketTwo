using UnityEngine;
using System.Collections;

public class SocketReconnectState : SocketStateBase {
    public SocketReconnectState(SocketClient socketClient) : base(socketClient)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        if (m_SocketClient != null && m_SocketClient.Socket != null)
        {
            m_SocketClient.Socket.Close();
            m_SocketClient.Socket = null;
            m_SocketClient.ClearMessageQueue();
        }

        m_SocketClient.isReconnect = true;
        //UIViewManager.Instance.ShowReconnectView();

        ChangeState(SocketClient.SocketState.Connect);
    }
}
