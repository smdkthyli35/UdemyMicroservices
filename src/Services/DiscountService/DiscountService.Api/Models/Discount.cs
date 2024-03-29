﻿namespace DiscountService.Api.Models
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
