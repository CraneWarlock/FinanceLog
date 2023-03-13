using AutoMapper;
using FinanceLog.Entites;
using FinanceLog.Exceptions;
using FinanceLog.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FinanceLog.Services
{
    public interface IFinanceLogsService
    {
        int Create(int userId, int groupId, CreateFinanceLogsDto dto);
        void Delete (int logId, int userId);
        FinanceLogsDto GetById (int logId, int userId);
        List<FinanceLogsDto> GetAll(int userId);
        List<FinanceLogsDto> GetByGroup(int userId, int groupId);
    }

    public class FinanceLogsService : IFinanceLogsService
    {
        private readonly FinanceLogDbContext _dbContext;
        private readonly IMapper _mapper;

        public FinanceLogsService(FinanceLogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int userId, int groupId, CreateFinanceLogsDto dto)
        {
            var user = GetUserById(userId);
            var group = GetGroupById(groupId);
            var logEntity = _mapper.Map<FinanceLogs>(dto);
            logEntity.UserId = userId;
            logEntity.GroupId = groupId;
            _dbContext.FinanceLogs.Add(logEntity);
            _dbContext.SaveChanges();
            return logEntity.Id;
        }

        public void Delete(int logId, int userId)
        {
            var user = GetUserById(userId);
            var log = _dbContext
                .FinanceLogs
                .FirstOrDefault(r => r.Id == logId && r.UserId == userId);
            if (log == null) throw new NotFoundException("Entry not found");
            _dbContext.FinanceLogs.Remove(log);
            _dbContext.SaveChanges();
        }

        public List<FinanceLogsDto> GetAll(int userId)
        {
            var user = GetUserById(userId);
            var financeLogsDtos = _mapper.Map<List<FinanceLogsDto>>(user.Id);
            return financeLogsDtos;
        }

        public List<FinanceLogsDto> GetByGroup(int userId, int groupId)
        {
            var member = GetGroupMember(userId, groupId);
            var financeLogsDtos = _mapper.Map<List<FinanceLogsDto>>(member.GroupId);
            return financeLogsDtos;
        }

        public FinanceLogsDto GetById(int logId, int userId)
        {
            var users = GetUserById(userId);
            var log = _dbContext
                .FinanceLogs
                .FirstOrDefault(d => d.Id == logId);
            if (log is null || log.UserId != userId) throw new NotFoundException("Entry not found");
            var financeLogDto = _mapper.Map<FinanceLogsDto>(log);
            return financeLogDto;
        }

        private User GetUserById(int userId)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(r => r.Id == userId);
            if (user == null) throw new NotFoundException("User not found");
            return user; 
        }

        private Entites.Group GetGroupById(int groupId)
        {
            var group = _dbContext
                .Groups
                .FirstOrDefault(r => r.Id == groupId);
            if(group == null) throw new NotFoundException("Group not found");
            return group;
        }

        private GroupMembers GetGroupMember(int userId, int groupId)
        {
            var member = _dbContext
                .GroupMembers
                .Where(r => r.UserId == userId && r.GroupId == groupId)
                .FirstOrDefault(r => r.UserId == userId);
            if (member == null) throw new NotFoundException("Group validation failed");
            return member;
        }
    }
}
