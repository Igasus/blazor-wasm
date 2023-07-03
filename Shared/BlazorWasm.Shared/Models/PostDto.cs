namespace BlazorWasm.Shared.Models;

public record PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}