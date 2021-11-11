using Common;
using Common.Logging;
using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
//using Model.Request;
using Service.Base;
using System;
using System.Linq;

namespace Service
{
    public class UserService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public UserService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<User> Login(User request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {

                using (var context = new ClientDbContext())
                {
                    User user = context.Users
                        //.Include(x => x.Role)
                        .Where(x => x.UserName == request.UserName).FirstOrDefault();

                    if (user != null)
                    {
                        response = new UtilitariesResponse<User>(config).setResponseBaseForObj(user);
                    }
                    else
                    {
                        response = new UtilitariesResponse<User>(config).setResponseBaseForBadCredentials(request);
                    }
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        //public EResponseBase<User> Get()
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<User> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            IQueryable<User> query = context.Users.Where(x => x.Enabled == true)
        //                .OrderByDescending(x => x.UserID);
        //            response = new UtilitariesResponse<User>(config).setResponseBaseForList(query);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}

        //public EResponseBase<User> GetById(int userId)
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<User> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            User user = context.Users
        //                .Where(x => x.UserID == userId)
        //                //.Include(x => x.Role)
        //                //.Include(x=>x.Region)
        //                //.Include(x=>x.Clinic)
        //                .FirstOrDefault();

        //            if (user != null)
        //            {
        //                response = new UtilitariesResponse<User>(config).setResponseBaseForObj(user);
        //            }
        //            else
        //            {
        //                response = new UtilitariesResponse<User>(config).setResponseBaseForNoDataFound();
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}

        //public EResponseBase<User> GetByFilters(User request)
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<User> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            IQueryable<User> query = context.Users
        //                //.Include(x=>x.Role)
        //                //.Include(x=>x.Region)
        //                //.Include(x=>x.Clinic)
        //                ;

        //            if (!string.IsNullOrEmpty(request.UserName)) query = query.Where(x => x.UserName == request.UserName);

        //            query.OrderBy(x => x.CreatedOn);

        //            response = new UtilitariesResponse<User>(config).setResponseBaseForList(query);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}

        //public EResponseBase<PagedResult<User>> GetByFiltersPaginated(User request)
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<PagedResult<User>> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            IQueryable<User> query = context.Users;
        //            if (!string.IsNullOrEmpty(request.UserName)) query = query.Where(x => x.UserName == request.UserName);

        //            PagedResult<User> paged = query.GetPaged(request.Page, request.RowsPerPage);

        //            response = new UtilitariesResponse<PagedResult<User>>(config).setResponseBaseForObj(paged);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<PagedResult<User>>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}

        //public EResponseBase<User> Insert(User request)
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<User> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            User user = context.Users
        //                .Where(x => x.UserName == request.UserName)
        //                .FirstOrDefault();

                    


        //            if (user == null)
        //            {

        //                if (request.Password != request.RepeatPassword)
        //                {
        //                    response = new UtilitariesResponse<User>(config).setResponseBasePasswordDontMatch(request);
        //                    return response; 
        //                }
        //                if (request.RoleID == 4 && request.RegionID == 0 )
        //                {
        //                    response = new UtilitariesResponse<User>(config).eResponseBaseForRoleRegionObligatory(request);
        //                    return response;
        //                }
        //                if (request.RegionID == 0 || request.RegionID == null) request.RegionID = null;
        //                if (request.ClinicID == 0 || request.RegionID == null) request.ClinicID = null;
        //                request.RoleID = (int)Enums.UserRole.User;
        //                request.CreatedOn = DateTime.Now;
        //                request.Enabled = true;
        //                context.Users.Add(request);
        //                context.SaveChanges();
        //                response = GetById(request.UserID);
        //            }
        //            else
        //            {
        //                response = new UtilitariesResponse<User>(config).setResponseBaseforExistingUser(request);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}

        /*public EResponseBase<User> Update(User request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    User user = context.Users
                        .Where(x => x.UserID == request.UserID)
                        .FirstOrDefault();

                    if (user != null)
                    {
                        context.Entry(user).State = EntityState.Modified;
                        //user.UpdatedOn = DateTime.Now;

                        context.SaveChanges();

                        response = GetById(request.UserID);
                    }
                    else
                    {
                        response = new UtilitariesResponse<User>(config).setResponseBaseForNoDataFound();
                    }

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }*/


        //public EResponseBase<User> Update(User model, int? Id)
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<User> response = null;
        //    try
        //    {
        //        if (Id > 0)
        //        {
        //            using (var context = new ClientDbContext())
        //            {
        //                User User = context.Users.Find(Id);
        //                context.Entry(User).State = EntityState.Modified;
        //                User.Name = string.IsNullOrEmpty(model.Name) ? User.Name : model.Name;
        //                User.FirstLastName = string.IsNullOrEmpty(model.FirstLastName) ? User.FirstLastName : model.FirstLastName;
        //                User.SecondLastName = string.IsNullOrEmpty(model.SecondLastName) ? User.SecondLastName : model.SecondLastName;
        //                User.Email = string.IsNullOrEmpty(model.Email) ? User.Email : model.Email;
        //                User.RoleID = model.RoleID;
        //                if( model.ClinicID == null || model.ClinicID == 0)
        //                {
        //                    User.ClinicID = null;
        //                }
        //                else
        //                {
        //                    User.ClinicID = model.ClinicID;
        //                }
        //                /*User.FirmPath = model.FirmPath;*/
        //                User.UpdatedOn = DateTime.Now;
        //                if (model.RoleID == 4 && model.RegionID == 0)
        //                {
        //                    response = new UtilitariesResponse<User>(config).eResponseBaseForRoleRegionObligatory(model);
        //                    return response;
        //                }
        //                if (model.RegionID == null || model.RegionID == 0) {
        //                    User.RegionID = null;
        //                }
        //                else
        //                {
        //                    User.RegionID = model.RegionID;
        //                }
        //                context.SaveChanges();
        //                response = new UtilitariesResponse<User>(config).setResponseBaseForOK(model);
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}


        //public EResponseBase<User> Enabled(int id)
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<User> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            User user = context.Users.Find(id);
        //            context.Entry(user).State = EntityState.Modified;
        //            user.Enabled = !user.Enabled;
        //            //user.UpdatedOn = DateTime.Now;
        //            context.SaveChanges();

        //            response = new UtilitariesResponse<User>(config).setResponseBaseForObj(user);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}

        //public EResponseBase<Role> GetRoles()
        //{
        //    Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
        //    EResponseBase<Role> response;
        //    try
        //    {
        //        using (var context = new ClientDbContext())
        //        {
        //            IQueryable<Role> query = context.Roles.Where(x => x.Enabled == true)
        //                .OrderByDescending(x => x.RoleID);
        //            response = new UtilitariesResponse<Role>(config).setResponseBaseForList(query);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response = new UtilitariesResponse<Role>(config).setResponseBaseForException(e);
        //        Logger.Error(e.Message);
        //    }

        //    return response;
        //}
    }
}
