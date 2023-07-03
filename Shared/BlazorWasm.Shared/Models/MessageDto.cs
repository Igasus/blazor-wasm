using System;

namespace BlazorWasm.Shared.Models;

public class MessageDto
{
    public string SenderUserName { get; set; }
    public string Content { get; set; }
    public DateTime SendTime { get; set; }
}