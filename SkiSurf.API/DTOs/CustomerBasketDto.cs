using SkiSurf.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SkiSurf.API.DTOs
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
