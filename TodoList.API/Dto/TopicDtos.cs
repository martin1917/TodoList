namespace TodoList.API.Dto
{
    public record TopicDto(int Id, string Name);
    
    public record CreateTopicDto(string Name);
    
    public record DeleteTopicDto(string Name);

    public record UpdateTopicDto(int Id, string Name);
}
