using AutoMapper;
using ElearningPlatform.Api.Data;
using ElearningPlatform.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ElearningPlatform.Api.Services
{
    public class ResultService : IResultService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ResultService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultDto>> GetByUserIdAsync(int userId)
        {
            var data = await _context.Results.AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.AttemptDate)
                .ToListAsync();

            return _mapper.Map<List<ResultDto>>(data);
        }
    }
}