﻿using AutoMapper;
using CatalogService.Api.Dtos;
using CatalogService.Api.Models;
using CatalogService.Api.Settings;
using MongoDB.Driver;
using UdemyMicroservices.Common.Dtos;

namespace CatalogService.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var mappedCategory = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(mappedCategory);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(mappedCategory), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category is null)
                return Response<CategoryDto>.Fail("Category not found!", 404);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
