﻿using LawAlert.Core.Models.Law;
using Microsoft.AspNetCore.Mvc;
using LawAlert.Core.Services.Law;
using LawAlert.Core.Services.Interest;
using LawAlert.Core.Services.Chapter;
using LawAlert.Core.Models.Chapter;
using Microsoft.AspNetCore.Authorization;

namespace LawAlert.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class ChapterController : Controller
    {
        private readonly IChapterService chapterService;
        private readonly ILogger logger;

        public ChapterController(IChapterService _chapterService,
                             ILogger logger)
        {
            this.chapterService = _chapterService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult All([FromQuery] AllChaptersQueryModel query, int id)
        {
            var queryResult = this.chapterService.All(
                query.SearchText,
                query.CurrentPage,
                query.ChaptersPerPage,
                id);

            query.LawName = queryResult.LawName;
            query.TotalChaptersCount = queryResult.TotalChaptersCount;
            query.Chapters = queryResult.Chapters;
            return View(query);
        }
    }
}
