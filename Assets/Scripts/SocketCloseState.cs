using UnityEngine;
using System.Collections;

public class SocketCloseState : SocketStateBase
{
    private bool m_isClosed;

    public SocketCloseState(SocketClient socketClient) : base(socketClient)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        m_isClosed = false;
        if (m_SocketClient != null && m_SocketClient.Socket != null)
        {
            m_SocketClient.Socket.Close();
            m_SocketClient.Socket = null;
            m_SocketClient.ClearMessageQueue();
        }
        m_SocketClient.isReconnect = false;
        m_isClosed = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isClosed)
        {
            m_isClosed = false;
            //UIViewManager.Instance.CloseReconnectView();

            if (m_SocketClient.onConnectComplete != null)
            {
                Debug.Log("连接服务器失败");
                m_SocketClient.onConnectComplete(false);
                m_SocketClient.onConnectComplete = null;
            }
            else
            {
                Debug.Log("网络连接断开");
                if (m_SocketClient.OnDisConnect != null)
                {
                    m_SocketClient.OnDisConnect(m_SocketClient.isActiveClose);
                }
            }

            ChangeState(SocketClient.SocketState.Idle);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

}
