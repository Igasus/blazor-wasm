using System.Threading.Tasks;
using BlazorWasm.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorWasm.Server.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(MessageDto message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}