﻿using CatalogService.Api.Dtos;
using CatalogService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservices.Common.ControllerBases;
using UdemyMicroservices.Common.Dtos;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Response<List<Dtos.CourseDto>> response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Response<Dtos.CourseDto> response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        //[HttpGet("[action]/{userId}")]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            Response<List<Dtos.CourseDto>> response = await _courseService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            Response<CourseDto> response = await _courseService.CreateAsync(courseCreateDto);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            Response<NoContent> response = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Response<NoContent> response = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
