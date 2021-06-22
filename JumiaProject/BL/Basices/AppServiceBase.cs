using AutoMapper;
using BL.Configuration;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Basices
{
   public class AppServiceBase : IDisposable
    {
        #region Vars
        protected IUnitofWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTR
        public AppServiceBase()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
