﻿using Dapper;
using DiscountService.Api.Models;
using Npgsql;
using System.Data;
using UdemyMicroservices.Common.Dtos;

namespace DiscountService.Api.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration, IDbConnection dbConnection)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("Delete From discount where id=@Id", new { Id = id });

            return status > 0
                ? Response<NoContent>.Success(204)
                : Response<NoContent>.Fail("Discount not found!", 404);
        }

        public async Task<Response<List<Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Discount>("Select * From discount");
            return Response<List<Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Discount>("Select * From discount where userid=@UserId and code=@Code", new { Code = code, UserId = userId });
            var hasDiscount = discounts.FirstOrDefault();
            if (hasDiscount is null)
                return Response<Discount>.Fail("Discount not found!", 404);

            return Response<Discount>.Success(hasDiscount, 200);
        }

        public async Task<Response<Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Discount>("Select * From discount where id=@Id", new { Id = id })).SingleOrDefault();

            if (discount is null)
                return Response<Discount>.Fail("Discount not found!", 404);

            return Response<Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("Insert Into discount (userid,rate,code) values (@UserId,@Rate,@Code)", discount);
            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error occured while adding.", 500);
        }

        public async Task<Response<NoContent>> Update(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("Update discount set userid=@UserId,code=@Code,rate=@Rate where id=@Id", new
            {
                Id = discount.Id,
                UserId = discount.UserId,
                Code = discount.Code,
                Rate = discount.Rate
            });

            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("Discount not found!", 404);
        }
    }
}
