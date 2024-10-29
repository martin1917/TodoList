using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.API.Data;
using TodoList.API.Dto;
using TodoList.API.Entities;

namespace TodoList.API.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TopicController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var topicEntities = await _context.Topics
                .AsNoTracking()
                .ToListAsync();

            var topicResults = topicEntities.Select(e => new TopicDto(e.Id, e.Name));

            return Ok(topicResults);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(CreateTopicDto dto)
        {
            var topic = new Topic { Name = dto.Name };
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return Ok(topic.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(UpdateTopicDto dto)
        {
            var topic = await _context.Topics
                .Where(e => e.Id == dto.Id)
                .FirstOrDefaultAsync();

            if (topic is null)
            {
                return BadRequest($"topic with {dto.Id} not exist");
            }

            topic.Name = dto.Name;
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();

            return Ok(new TopicDto(topic.Id, topic.Name));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (topic is null)
            {
                return BadRequest($"topic with {id} not exist");
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return Ok(id);
        }
    }
}
