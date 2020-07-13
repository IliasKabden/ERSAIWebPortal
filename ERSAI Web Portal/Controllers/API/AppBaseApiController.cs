using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERSAI_Web_Portal.Controllers.API
{
    public class AppBaseApiController : ApiController
    {
        private ERSAIContext _ERSAIDB;
        protected ERSAIContext ERSAIDB
        {
            get
            {
                if (_ERSAIDB == null)
                    _ERSAIDB = new ERSAIContext();
                return _ERSAIDB;
            }
        }
        private PayslipContext _PayslipsDb;
        protected PayslipContext PayslipsDb
        {
            get
            {
                if (_PayslipsDb == null)
                    _PayslipsDb = new PayslipContext();
                return _PayslipsDb;
            }
        }
        private IMSContext _IMSDB;
        protected IMSContext IMSDB
        {
            get
            {
                if (_IMSDB == null)
                    _IMSDB = new IMSContext();
                return _IMSDB;
            }
        }
        protected MvcApplication App
        {
            get
            {
                return MvcApplication.Current;
            }
        }
        protected AppUser AppUser
        {
            get
            {
                return ERSAIDB.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ERSAIDB?.Dispose();
                _IMSDB?.Dispose();
                _PayslipsDb?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}