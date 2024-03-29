using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPPacket(Packet _packet){
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet){
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    public static void WelcomeReceived(){
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write("Username");

            SendTCPPacket(_packet);
        }
    }

    public static void Queue(bool _joining){
        using (Packet _packet = new Packet((int)ClientPackets.queue))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write("Baby boy");
            _packet.Write(_joining);

            SendTCPPacket(_packet);
        }
    }

    public static void PlayerMovement(bool[] _inputs){
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach(bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }

    public static void PlayerShoot(Vector3 _facing){
        using (Packet _packet = new Packet((int)ClientPackets.playerShoot))
        {
            _packet.Write(_facing);

            SendTCPPacket(_packet);
        }
    }

    public static void PlayerThrowItem(Vector3 _facing){
        using (Packet _packet = new Packet((int)ClientPackets.playerThrowItem))
        {
            _packet.Write(_facing);

            SendTCPPacket(_packet);
        }
    }
}
