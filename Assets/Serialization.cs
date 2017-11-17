using System.Runtime.Serialization;
using UnityEngine;

[DataContract] public class Server {
    [DataMember] public string serverName;
    [DataMember] public string mode;
    [DataMember] public int connectedPlayers;
    [DataMember] public int playerLimit;
    [DataMember] public bool passwordProtected;
    [DataMember] public int build;

    public Server(HostData hostData) {
        serverName = hostData.gameName;
        mode = hostData.comment.Substring(6);
        connectedPlayers = hostData.connectedPlayers;
        playerLimit = hostData.playerLimit;
        passwordProtected = hostData.passwordProtected;
        int.TryParse(hostData.comment.Substring(0, 6), out build);
    }
}

[DataContract] public class ServerList {
    [DataMember] public Server[] servers;

    public ServerList(HostData[] data) {
        servers = new Server[data.Length];
        for (int i = 0; i < data.Length; ++i) {
            servers[i] = new Server(data[i]);
        }
    }
}
