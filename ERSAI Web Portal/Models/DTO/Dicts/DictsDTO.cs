using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERSAI_Web_Portal.Controllers.AppBaseMVCController;

namespace ERSAI_Web_Portal.Models.DTO.Dicts
{
    public class DictsDTO
    {
        public DateTime? LastRefreshTime { get; set; }
        public Func<MVCControllerDbContexts, string> DictsRetrievalFunction { get; set; }
        public string JSON { get; set; }
        public void Refresh(MVCControllerDbContexts contextsToUse)
        {
            JSON = DictsRetrievalFunction.Invoke(contextsToUse);
            LastRefreshTime = DateTime.Now;
        }
    }
}