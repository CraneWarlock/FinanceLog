using AutoMapper;
using FinanceLog.Entites;
using FinanceLog.Models;

namespace FinanceLog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FinanceLogs, FinanceLogsDto>();
        }

    }
}
