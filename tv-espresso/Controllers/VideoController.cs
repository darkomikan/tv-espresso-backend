using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tv_espresso.Models;
using tv_espresso.Services;

namespace tv_espresso.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VideoController : ControllerBase
    {
        private readonly VideoService videoService;

        public VideoController(VideoService videoService) => this.videoService = videoService;

        [HttpGet]
        public IActionResult Status()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetDuration(string uri)
        {
            TimeSpan? duration = videoService.GetDuration(uri);
            if (duration is null)
                return NotFound();
            return Ok($"{duration:g}");
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Video>> Get(string id)
        {
            var video = await videoService.GetAsync(id);
            if (video is null)
                return NotFound();
            return video;
        }

        [HttpGet]
        public async Task<List<Video>> GetAll() => await videoService.GetAsync();

        [HttpGet]
        public async Task<List<Video>> GetMatching(string phrase) => await videoService.GetMatchingAsync(phrase.Trim());

        [HttpGet]
        public async Task<List<Video>> GetByGenre(string genre) => await videoService.GetByGenreAsync(genre.Trim());

        [HttpGet]
        public async Task<List<Video>> GetByActor(string actor) => await videoService.GetByActorAsync(actor.Trim());

        [HttpGet]
        public async Task<List<Video>> GetByDirector(string director) => await videoService.GetByDirectorAsync(director.Trim());

        [HttpPost]
        public async Task<IActionResult> EnsureEmbeddedSubtitles(Video video)
        {
            bool extChanged;
            bool fetchNeeded = false;
            if (video.Uri4k is not null && video.Uri4k != "")
            {
                extChanged = await videoService.EnsureEmbeddedSubtitlesAsync(video.Uri4k, video.SubtitleSrbUri!, video.SubtitleEngUri!);
                if (extChanged)
                {
                    video.Uri4k = video.Uri4k.Replace(Path.GetExtension(video.Uri4k), ".mkv");
                    fetchNeeded = true;
                }
            }
            extChanged = await videoService.EnsureEmbeddedSubtitlesAsync(video.Uri, video.SubtitleSrbUri!, video.SubtitleEngUri!);
            if (extChanged)
            {
                video.Uri = video.Uri.Replace(Path.GetExtension(video.Uri), ".mkv");
                fetchNeeded = true;
            }
            if (fetchNeeded)
            {
                await videoService.UpdateAsync(video);
                return Ok(video);
            }
            return Ok(fetchNeeded);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Video video)
        {
            await videoService.InsertAsync(video);
            return CreatedAtAction(nameof(Get), new { id = video.Id }, video);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Video video)
        {
            if (video.Id is null)
                return BadRequest();
            await videoService.UpdateAsync(video);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            await videoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
