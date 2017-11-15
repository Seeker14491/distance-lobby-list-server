using UnityEngine;

public class ServerInfo {
    private HostData hostData;

    public ServerInfo(HostData hostdata) {
        hostData = hostdata;
    }

    public string ServerName() => hostData.gameName;

    public string Mode() => hostData.comment.Substring(6);
    
    public int ConnectedPlayers() {
        return hostData.connectedPlayers;
    }

    public int PlayerLimit() {
        return hostData.playerLimit;
    }

    public bool ServerIsFull() {
        return ConnectedPlayers() >= PlayerLimit();
    }

    public bool PasswordProtected() {
        return hostData.passwordProtected;
    }

    public int Build() {
        int result = 0;
        int.TryParse(hostData.comment.Substring(0, 6), out result);
        return result;
    }
}
